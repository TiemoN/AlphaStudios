using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zerstörbar : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)

    {
        if(other.gameObject.CompareTag("Explosion"))
        {
            Destroy(this.gameObject);
        }
    }
}
