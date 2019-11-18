using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank2 : MonoBehaviour
{
    public GameObject Tanktop;
    public int speed, rotspeed;
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Input.GetAxis("P2Vertical") * Time.deltaTime);
        transform.Rotate(Vector3.down * rotspeed * Input.GetAxis("P2Horizontal") * Time.deltaTime);
        Tanktop.transform.Rotate(Vector3.back * rotspeed * Input.GetAxis("P2HorizontalRight") * Time.deltaTime);
    }
}
