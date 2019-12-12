using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank4canon : MonoBehaviour
{
    public GameObject canonball;
    public float setcooldown;
    float cooldown;
    //Steurung Controller4 anpassen
    void Update()
    {
        cooldown = cooldown - Time.deltaTime;
        if (Input.GetAxis("P4RightTrigger") > 0)
        {
            if (cooldown <= 0)
            {
                shoot();
            }
        }
    }
    IEnumerator Multishot()
    {
        shoot();
        yield return new WaitForSeconds(0.1f);
        shoot();
        yield return new WaitForSeconds(0.1f);
        shoot();
        yield return new WaitForSeconds(0.1f);
        shoot();
        yield return new WaitForSeconds(0.1f);
        shoot();
    }

    void shoot()
    {
        canonball.transform.position = transform.position;
        canonball.transform.rotation = transform.rotation;
        GameObject NewCanonBall = Instantiate(canonball);
        cooldown = setcooldown;
    }
}
