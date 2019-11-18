using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank1canon : MonoBehaviour
{
    public GameObject canonball;
    public float setcooldown;
    float cooldown;

    void Update()
    {
        cooldown = cooldown - Time.deltaTime;
        if (Input.GetAxis("P1RightTrigger") > 0)
        {
            if (cooldown <= 0)
            {
                canonball.transform.position = transform.position;
                canonball.transform.rotation = transform.rotation;
                GameObject NewCanonBall = Instantiate(canonball);
                cooldown = setcooldown;
            }
        }
    }
}
