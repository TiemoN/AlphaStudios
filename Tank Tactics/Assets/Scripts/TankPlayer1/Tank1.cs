using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank1 : MonoBehaviour
{
    public GameObject Tanktop;
    public int speed ,rotspeed;
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Input.GetAxis("P1Vertical") * Time.deltaTime);
        transform.Rotate(Vector3.down * rotspeed * Input.GetAxis("P1Horizontal") * Time.deltaTime);
        Tanktop.transform.Rotate(Vector3.back * rotspeed * Input.GetAxis("P1HorizontalRight") * Time.deltaTime);
    }
}
