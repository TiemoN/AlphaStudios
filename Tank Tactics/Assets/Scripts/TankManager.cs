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
