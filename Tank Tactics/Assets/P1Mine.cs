using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1Mine : MonoBehaviour
{
    public int despawntime;
    void Start()
    {
        
    }
    IEnumerator Sespawn()
    {
        yield return new WaitForSeconds(despawntime);
        Destroy(this.gameObject);
    }
}
