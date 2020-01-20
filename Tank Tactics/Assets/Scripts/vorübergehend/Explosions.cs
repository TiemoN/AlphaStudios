using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosions : MonoBehaviour
{ public GameObject Explode;
    public ParticleSystem Radius;
   
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "canonball")
        {
            Explode = Instantiate(Explode, transform.position, Quaternion.Euler(-90f, 0f, 0f));
            Radius = Instantiate(Radius, transform.position, Quaternion.Euler(90f, 0f, 0f));
        }
        
        
    }
}
