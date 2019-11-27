using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canonball : MonoBehaviour
{
    public Rigidbody rb;
    public int speed;
    bool bounce;
    void Start()
    {
        rb.AddRelativeForce(Vector3.forward * speed);
    }
    private void OnCollisionExit(Collision collision)
    {
        if (bounce)
        {
            Destroy(this.gameObject);
        }
        bounce = true;
    }
}