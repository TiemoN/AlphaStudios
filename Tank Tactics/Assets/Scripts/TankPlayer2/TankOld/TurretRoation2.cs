using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretRoation2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Joystick1Button9))
        {
            transform.Rotate(-Vector3.forward, 100 * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.Joystick1Button9))
            transform.Rotate(Vector3.forward, 100 * Time.deltaTime);
    }
}
