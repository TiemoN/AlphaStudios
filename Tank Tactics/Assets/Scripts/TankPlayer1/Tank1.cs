using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank1 : MonoBehaviour
{
    public GameObject Tanktop;
    [Range(1.0f, 10.0f)]
    [Tooltip("Defines the speed multiplier")]
    [Header("Player Movement Settings")]
    public float speed;
    [Range(1.0f, 100.0f)]
    [Tooltip("Defines the rotspeed multiplier")]
    public float rotspeed;
    public bool advancedControl;
    float winkel;

    void Update()
    {
        if (advancedControl)
        {
            transform.Translate(Vector3.forward * speed * Input.GetAxis("P1Vertical") * Time.deltaTime);
            transform.Rotate(Vector3.down * rotspeed * Input.GetAxis("P1Horizontal") * Time.deltaTime);
            Tanktop.transform.Rotate(Vector3.back * rotspeed * Input.GetAxis("P1HorizontalRight") * Time.deltaTime);
        }
        else
        {
            if(Input.GetAxis("P1Vertical") != 0 || Input.GetAxis("P1Horizontal") != 0)
            {
                winkel = Mathf.Atan2(Input.GetAxis("P1Horizontal"), Input.GetAxis("P1Vertical")) * Mathf.Rad2Deg;
                if(winkel < 0)
                {
                    winkel = winkel + 360;
                }
                winkel = 360 - winkel;
                if(winkel == 360)
                {
                    winkel = 0;
                }
                if(winkel != this.transform.rotation.y)
                {
                    if(winkel - this.transform.rotation.y <= 0)
                    {
                        transform.Rotate(Vector3.down * -rotspeed * Time.deltaTime);
                    }
                    else
                    {
                        transform.Rotate(Vector3.down * rotspeed * Time.deltaTime);
                    }
                }
            }
        }
    }
    //steuerung nicht relativ machen
    //items mariokart
}
