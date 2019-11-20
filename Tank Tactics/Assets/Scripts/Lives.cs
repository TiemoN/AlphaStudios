using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lives : MonoBehaviour
{
    public float lives;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("canonball"))
        {
            lives--;
            if(lives <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
