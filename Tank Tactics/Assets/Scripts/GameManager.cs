using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int numRoundsToWin = 3;            
    public float startDelay = 3f;             
    public float endDelay = 3f;               
    public CameraControl cameraControl;      
    public Text messageText;                  
    public GameObject[] tankPrefab;            
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
            
            tanks[i].instance =
                Instantiate(tankPrefab[i], Vector3.zero, Quaternion.Euler(Vector3.zero)) as GameObject;
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

        
        cameraControl.targets = targets;
    }


    
    private IEnumerator GameLoop()
    {
        
        yield return StartCoroutine(RoundStarting());

        
        yield return StartCoroutine(RoundPlaying());

    
        yield return StartCoroutine(RoundEnding());

        
        if (gameWinner != null)
        {

            SceneManager.LoadScene(1);
        }
        else
        {
            
            StartCoroutine(GameLoop());
        }
    }


    private IEnumerator RoundStarting()
    {
       
        ResetAllTanks();
        DisableTankControl();

        
        cameraControl.SetStartPositionAndSize();

        
        roundNumber++;
        messageText.text = "ROUND " + roundNumber;

       
        yield return startWait;
    }


    private IEnumerator RoundPlaying()
    {
        
        EnableTankControl();

        
        messageText.text = string.Empty;

       
        while (!OneTankLeft())
        {
            
            yield return null;
        }
    }


    private IEnumerator RoundEnding()
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
