using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShellShoot : MonoBehaviour
{
    public Rigidbody rb;
    public int speed;
    bool bounce;

    public GameObject Explode;

    void Start()
    {
        rb.AddRelativeForce(Vector3.forward * speed);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (bounce)
        {
            Destroy(this.gameObject);
        }
        bounce = true;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Players")
        {
            Destroy(gameObject);
        }
        if (other.tag == "canonball")
        {
            Destroy(gameObject);
        }
        if (other.tag == "canonball")
        {
            Explode = Instantiate(Explode, transform.position, Quaternion.identity);
        }

    }
}
