using System;
using UnityEngine;

[Serializable]
public class TankManager
{
    public Color playerColor;
    public Transform spawnPoint;
    [HideInInspector] public int playerNumber;
    [HideInInspector] public string coloredPlayerText;
    [HideInInspector] public GameObject instance;
    [HideInInspector] public int wins;
    int tankID;

    private Tank1 movement1;
    private Tank1canon shooting1;
    private Tank2 movement2;
    private Tank2canon shooting2;
    private Tank3 movement3;
    private Tank3canon shooting3;
    private Tank4 movement4;
    private Tank4canon shooting4;
    //private GameObject canvasGameObject;

    public void Setup()
    {
       switch(tankID)
        {
            case 1:
                movement1 = instance.GetComponent<Tank1>();
                shooting1 = instance.GetComponent<Tank1canon>();
                break;
            case 2:
                movement2 = instance.GetComponent<Tank2>();
                shooting2 = instance.GetComponent<Tank2canon>();
                break;
            case 3:
                movement3 = instance.GetComponent<Tank3>();
                shooting3 = instance.GetComponent<Tank3canon>();
                break;
            case 4:
                movement4 = instance.GetComponent<Tank4>();
                shooting4 = instance.GetComponent<Tank4canon>();
                break;

        }
            //canvasGameObject = instance.GetComponent<Canvas>().gameObject;

        //movement.playerNumber = playerNumber;
        //shooting.playerNumber = playerNumber;

        coloredPlayerText = "<color=#" + ColorUtility.ToHtmlStringRGB(playerColor) + ">PLAYER " + playerNumber + "</color>";

        MeshRenderer renderer = instance.GetComponentInChildren<MeshRenderer>();

       
           renderer.material.color = playerColor;
        
    }

    public void DisableControl()
    {
        switch (tankID)
        {
            case 1:
                movement1.enabled = false;
                shooting1.enabled = false;
                break;
            case 2:
                movement2.enabled = false;
                shooting2.enabled = false;
                break;
            case 3:
                movement3.enabled = false;
                shooting3.enabled = false;
                break;
            case 4:
                movement4.enabled = false;
                shooting4.enabled = false;
                break;
        }
        //canvasGameObject.SetActive(false);
    }

    public void EnableControl()
    {
        switch (tankID)
        {
            case 1:
                movement1.enabled = true;
                shooting1.enabled = true;
                break;
            case 2:
                movement2.enabled = true;
                shooting2.enabled = true;
                break;
            case 3:
                movement3.enabled = true;
                shooting3.enabled = true;
                break;
            case 4:
                movement4.enabled = true;
                shooting4.enabled = true;
                break;
        }

        //canvasGameObject.SetActive(true);
    }

    public void Reset()
    {
        instance.transform.position = spawnPoint.position;
        instance.transform.rotation = spawnPoint.rotation;

        instance.SetActive(false);
        instance.SetActive(true);
    }
}
