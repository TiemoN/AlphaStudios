using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class SpielManager : MonoBehaviour
{
    public int numRoundsToWin = 3;
    public float startDelay = 3f;
    public float endDelay = 3f;
    public CameraControl cameraControl;
    public Text messageText;
    public GameObject tankPrefab;
    public TankManager[] tanks;

    private int roundNumber;
    private WaitForSeconds startWait;
    private WaitForSeconds endWait;
    private TankManager roundWinner;
    private TankManager gameWinner;

    private void Start()
    {
        startWait = new WaitForSeconds(startDelay);
        endWait = new WaitForSeconds(endDelay);

        SpawnAllTanks();
        SetCameraTargets();

        StartCoroutine(GameLoop());
    }

    private void SpawnAllTanks()
    {
        for (int i = 0; i < tanks.Length; i++)
        {
            tanks[i].instance = Instantiate(tankPrefab, tanks[i].spawnPoint.position, tanks[i].spawnPoint.rotation) as GameObject;
            tanks[i].playerNumber = i + 1;
            tanks[i].Setup();
        }
    }

    private void SetCameraTargets()
    {
        
        Transform[] targets = new Transform[tanks.Length];

        for (int i = 0; i < targets.Length; i++)
        {
            targets[i] = tanks[i].instance.transform;
        }

        cameraControl.m_Targets = targets;
    }

    private IEnumerator GameLoop()
    {
        yield return StartCoroutine(roundStarting());

       
        yield return StartCoroutine(roundPlaying());

      
        yield return StartCoroutine(roundEnding());

     
        if (gameWinner != null)
        {
            Application.LoadLevel(Application.loadedLevel);
        }
        else
        {
            StartCoroutine(GameLoop());
        }
    }
    private IEnumerator roundStarting()
    {
        ResetAllTanks();
        DisableTankControl();

        cameraControl.SetStartPositionAndSize();

        roundNumber++;
        messageText.text = "ROUND " + roundNumber;

        yield return startWait;
    }
    private IEnumerator roundPlaying()
    {
        
        EnableTankControl();

       
        messageText.text = string.Empty;

        
        while (!OneTankLeft())
        {
            
            yield return null;
        }
    }
    private IEnumerator roundEnding()
    {
       
        DisableTankControl();

        roundWinner = null;
        
        roundWinner = GetRoundWinner();

        if (roundWinner != null)
            roundWinner.wins++;

        gameWinner = GetGameWinner();

        string message = EndMessage();
        messageText.text = message;

       
        yield return endWait;
    }
    private bool OneTankLeft()
    {
        int numTanksLeft = 0;

        for (int i = 0; i < tanks.Length; i++)
        {
            if (tanks[i].instance.activeSelf)
                numTanksLeft++;
        }

        return numTanksLeft <= 1;
    }

    private TankManager GetRoundWinner()
    {
        for (int i = 0; i < tanks.Length; i++)
        {
            if (tanks[i].instance.activeSelf)
                return tanks[i];
        }

        return null;
    }
    private TankManager GetGameWinner()
    {
        for (int i = 0; i < tanks.Length; i++)
        {
            if (tanks[i].wins == numRoundsToWin)
                return tanks[i];
        }
        return null;
    }
    private string EndMessage()
    {
        string message = "DRAW!";

        if (roundWinner != null)
            message = roundWinner.coloredPlayerText + " WINS THE ROUND!";

        message += "\n\n\n\n";

        for (int i = 0; i < tanks.Length; i++)
        {
            message += tanks[i].coloredPlayerText + ": " + tanks[i].wins + " WINS\n";
        }

        if (gameWinner != null)
            message = gameWinner.coloredPlayerText + " WINS THE GAME!";

        return message;
    }


    private void ResetAllTanks()
    {
        for (int i = 0; i < tanks.Length; i++)
        {
            tanks[i].Reset();
        }
    }


    private void EnableTankControl()
    {
        for (int i = 0; i < tanks.Length; i++)
        {
            tanks[i].EnableControl();
        }
    }


    private void DisableTankControl()
    {
        for (int i = 0; i < tanks.Length; i++)
        {
            tanks[i].DisableControl();
        }
    }
}

