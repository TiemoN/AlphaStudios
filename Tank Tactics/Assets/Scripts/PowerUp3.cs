using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp3 : MonoBehaviour
{
    public float multiplier = 1.0f;

    public GameObject pickupEffect;


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Pickup(other);
        }
    }
    void Pickup(Collider player)
    {
        // Zeigt in der Console ob ein Objekt aufgenommen wurde
        Debug.Log("PowerUp picked up");
        // Grafik Effekt wenn Objekt aufgenommen wird
        Instantiate(pickupEffect, transform.position, transform.rotation);
        // PowerUp Effekt für den Spieler
        Lives stats = player.GetComponent<Lives>();
        stats.lives *= multiplier;

        // Wait x amount of seconds


        // Reverse the effect on our player
        //stats.m_Speed /= multiplier;

        // Entfernt PowerUp Objekt
        Destroy(gameObject);
    }

}
