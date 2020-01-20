using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {

    public float multiplier = 1.4f;

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
        player.transform.localScale *= multiplier;
        // Entfernt PowerUp Objekt
        Destroy(gameObject);
    


    }
}
