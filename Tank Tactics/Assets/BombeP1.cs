using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombeP1 : MonoBehaviour
{
    public GameObject bombe, Expllosion, Particle;
    public int speed, fallspeed;
    public Rigidbody rb;
    float lifetime;
    void Update()
    {
        rb.isKinematic = false;
        lifetime = lifetime + Time.deltaTime;
        if (bombe.activeSelf == false && Expllosion.activeSelf == false)
        {
            transform.Translate(Vector3.back * Input.GetAxis("P1VerticalRight") * speed * Time.deltaTime);
            transform.Translate(Vector3.left * Input.GetAxis("P1HorizontalRight") * speed * Time.deltaTime);
        }

        if(Input.GetAxis("P1LeftTrigger") != 0 && bombe.activeSelf == false && Expllosion.activeSelf == false && lifetime > 1)
        {
            bombe.transform.position = this.transform.position + Vector3.up * 20;
            bombe.SetActive(true);
            rb.AddForce(Vector3.down * fallspeed);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == bombe)
        {
            rb.isKinematic = true;
            bombe.SetActive(false);
            Expllosion.SetActive(true);
            Particle.SetActive(true);
            StartCoroutine("aus");
        }

    }
    IEnumerator aus()
    {
        yield return new WaitForSeconds(0.15f);
        lifetime = 0;
        Expllosion.SetActive(false);
        Particle.SetActive(false);
        this.gameObject.SetActive(false);
    }
}
