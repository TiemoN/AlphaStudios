using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2Mine : MonoBehaviour
{
    public int despawntime;
    public GameObject Explosion, Particle, Mine;
    void Start()
    {
        StartCoroutine("Despawn");
    }
    IEnumerator Despawn()
    {
        yield return new WaitForSeconds(despawntime);
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("P2"))
        {
            Explosion.SetActive(true);
            Particle.SetActive(true);
            StartCoroutine("explodiert");
        }
    }

    IEnumerator explodiert()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(Mine.gameObject);
    }
}
