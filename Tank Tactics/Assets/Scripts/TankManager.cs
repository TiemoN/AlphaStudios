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

    private Tank1 movement;
    private Tank1canon shooting;
    private GameObject canvasGameObject;

    public void Setup()
    {
        movement = instance.GetComponent<Tank1>();
        shooting = instance.GetComponent<Tank1canon>();
        //canvasGameObject = instance.GetComponent<Canvas>().gameObject;

        //movement.playerNumber = playerNumber;
        //shooting.playerNumber = playerNumber;

        coloredPlayerText = "<color=#" + ColorUtility.ToHtmlStringRGB(playerColor) + ">PLAYER " + playerNumber + "</color>";

        MeshRenderer renderer = instance.GetComponentInChildren<MeshRenderer>();

       
           renderer.material.color = playerColor;
        
    }

    public void DisableControl()
    {
        movement.enabled = false;
        shooting.enabled = false;

        canvasGameObject.SetActive(false);
    }

    public void EnableControl()
    {
        movement.enabled = true;
        shooting.enabled = true;

        canvasGameObject.SetActive(true);
    }

    public void Reset()
    {
        instance.transform.position = spawnPoint.position;
        instance.transform.rotation = spawnPoint.rotation;

        instance.SetActive(false);
        instance.SetActive(true);
    }
}
