using System;
using UnityEngine;

[Serializable]
public class RoundManager1vs1H
{
    public Color m_PlayerColor;
    public Transform m_SpawnPoint;
    [HideInInspector] public int m_PlayerNumber;
    [HideInInspector] public string m_ColoredPlayerText;
    [HideInInspector] public GameObject m_Instance;
    [HideInInspector] public int m_Wins;


    private TankMovement1vs1H m_Movement;
    private TankShooting1vs1H m_Shooting;
    //private GameObject m_CanvasGameObject;                   

    public void Setup()
    {
        m_Movement = m_Instance.GetComponent<TankMovement1vs1H>();
        m_Shooting = m_Instance.GetComponent<TankShooting1vs1H>();
        //m_CanvasGameObject = m_Instance.GetComponentInChildren<Canvas>().gameObject;

        // Set the player numbers to be consistent across the scripts.
        m_Movement.m_PlayerNumber = m_PlayerNumber;
        m_Shooting.m_PlayerNumber = m_PlayerNumber;

        // Create a string using the correct color that says 'PLAYER 1' etc based on the tank's color and the player's number.
        m_ColoredPlayerText = "<color=#" + ColorUtility.ToHtmlStringRGB(m_PlayerColor) + ">PLAYER " + m_PlayerNumber + "</color>";

        // Get all of the renderers of the tank.
        MeshRenderer[] renderers = m_Instance.GetComponentsInChildren<MeshRenderer>();

        // Go through all the renderers...
        for (int i = 0; i < renderers.Length; i++)
        {
            // ... set their material color to the color specific to this tank.
            renderers[i].material.color = m_PlayerColor;
        }
    }

    // Used during the phases of the game where the player shouldn't be able to control their tank.
    public void DisableControl()
    {
        m_Movement.enabled = false;
        m_Shooting.enabled = false;

        //m_CanvasGameObject.SetActive(false);


    }

    // Used during the phases of the game where the player should be able to control their tank.
    public void EnableControl()
    {
        m_Movement.enabled = true;
        m_Shooting.enabled = true;

        //m_CanvasGameObject.SetActive(true);
    }

    // Used at the start of each round to put the tank into it's default state.
    public void Reset()
    {
        m_Instance.transform.position = m_SpawnPoint.position;
        m_Instance.transform.rotation = m_SpawnPoint.rotation;

        m_Instance.SetActive(false);
        m_Instance.SetActive(true);

        switch (m_Movement.powerup)
        {
            //SpeedBoost
            case 0:
                if (m_PlayerNumber == 1)
                {
                    m_Movement.uiSpeedBoostLogo1.gameObject.SetActive(false);
                }
                else if (m_PlayerNumber == 2)
                {
                    m_Movement.uiSpeedBoostLogo2.gameObject.SetActive(false);
                }
                else if (m_PlayerNumber == 3)
                {
                    //m_Movement.uiSpeedBoostLogo3.gameObject.SetActive(false);
                }
                else
                {
                    //m_Movement.uiSpeedBoostLogo4.gameObject.SetActive(false);
                }
                break;
            //RapidFire
            case 1:
                if (m_PlayerNumber == 1)
                {
                    m_Movement.uiPowerUpLogo1.gameObject.SetActive(false);
                }
                else if (m_PlayerNumber == 2)
                {
                    m_Movement.uiPowerUpLogo2.gameObject.SetActive(false);
                }
                else if (m_PlayerNumber == 3)
                {
                    //m_Movement.uiPowerUpLogo3.gameObject.SetActive(false);
                }
                else
                {
                    //m_Movement.uiPowerUpLogo4.gameObject.SetActive(false);
                }
                break;
            //PenShot   
            case 2:
                if (m_PlayerNumber == 1)
                {
                    m_Movement.uiPenShotLogo1.gameObject.SetActive(false);
                }
                else if (m_PlayerNumber == 2)
                {
                    m_Movement.uiPenShotLogo2.gameObject.SetActive(false);
                }
                else if (m_PlayerNumber == 3)
                {
                    //m_Movement.uiPenShotLogo3.gameObject.SetActive(false);
                }
                else
                {
                    //m_Movement.uiPenShotLogo4.gameObject.SetActive(false);
                }
                break;
        }
        m_Movement.powerup = -1;
    }
}