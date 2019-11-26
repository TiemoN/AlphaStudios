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

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Input.GetAxis("P1Vertical") * Time.deltaTime);
        transform.Rotate(Vector3.down * rotspeed * Input.GetAxis("P1Horizontal") * Time.deltaTime);
        Tanktop.transform.Rotate(Vector3.back * rotspeed * Input.GetAxis("P1HorizontalRight") * Time.deltaTime);
    }
}
