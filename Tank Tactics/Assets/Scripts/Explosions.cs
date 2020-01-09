using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosions : MonoBehaviour
{ public GameObject Explode;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "canonball")
        {
            Explode = Instantiate(Explode, transform.position, Quaternion.identity);
        }
        
        
    }
}
