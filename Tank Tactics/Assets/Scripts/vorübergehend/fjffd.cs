using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canonball : MonoBehaviour
{
    public Rigidbody rb;
    public int speed;
    bool bounce;
    public ParticleSystem BounceExplosion;

    void Start()
    {
        rb.AddRelativeForce(Vector3.forward * speed);


    }
    private void OnCollisionEnter(Collision collision)

    {
        if (bounce)
        {

            Destroy(this.gameObject);
            Instantiate(BounceExplosion, transform.position, Quaternion.identity);

        }
        bounce = true;

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "P2")
        {
            Destroy(gameObject);
        }
        if (other.tag == "P1")
        {
            Destroy(gameObject);
        }
        if (other.tag == "P3")
        {
            Destroy(gameObject);
        }
        if (other.tag == "P4")
        {
            Destroy(gameObject);
        }
        if (other.tag
            == "canonball")
        {
            Destroy(gameObject);
        }

    }

}