using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawn : MonoBehaviour
{
    public GameObject powerUpSpawn;
    public int numToSpawn;
    public Transform[] loQuadrant;
    public Transform[] luQuadrant;
    public Transform[] roQuadrant;
    public Transform[] ruQuadrant;

    private int arrayIndex;
    void Start()
    {


        int spawned = 0;

        while (spawned < numToSpawn)
        {
            //position = new Vector3(Random.Range(-18.0f, 18.0f), 1, Random.Range(-11.0f, 11.0f));

            //Spawn on a random Position inside of the LO(LinksOben) Quadrant
            arrayIndex = Random.Range(0,loQuadrant.Length);
            Instantiate(powerUpSpawn, loQuadrant[arrayIndex].position, Quaternion.identity);
            spawned++;
            //Spawn on a random Position inside of the LU(LinksUNTEN) Quadrant
            arrayIndex = Random.Range(0, luQuadrant.Length);
            Instantiate(powerUpSpawn, luQuadrant[arrayIndex].position, Quaternion.identity);
            spawned++;
            //Spawn on a random Position inside of the rO(rechtsOben) Quadrant
            arrayIndex = Random.Range(0, roQuadrant.Length);
            Instantiate(powerUpSpawn, roQuadrant[arrayIndex].position, Quaternion.identity);
            spawned++;
            //Spawn on a random Position inside of the rO(rechtsOben) Quadrant
            arrayIndex = Random.Range(0, roQuadrant.Length);
            Instantiate(powerUpSpawn, roQuadrant[arrayIndex].position, Quaternion.identity);
            spawned++;
        }
    }
   
}
   
