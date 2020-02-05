using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawn : MonoBehaviour
{
    public float m_StartDelay = 10f;
    //public float m_EndDelay = 3f;
    public GameObject powerUpSpawn;
    [SerializeField] int maximumCountOfItemsPerDraw = 2;
    public Transform[] loQuadrant;//UL
    public Transform[] luQuadrant;//LL
    public Transform[] roQuadrant;//UR
    public Transform[] ruQuadrant;//LR

    private int arrayIndex;

    bool isRoundEnded = false;
    public void DestroyPowerUps()
    {
        isRoundEnded = true;

        foreach (var spawnPoint in loQuadrant)
        {
            foreach (Transform children in spawnPoint)
            {
                Destroy(children.gameObject);
            }
        }
        foreach (var spawnPoint in luQuadrant)
        {
            foreach (Transform children in spawnPoint)
            {
                Destroy(children.gameObject);
            }
        }
        foreach (var spawnPoint in roQuadrant)
        {
            foreach (Transform children in spawnPoint)
            {
                Destroy(children.gameObject);
            }
        }
        foreach (var spawnPoint in ruQuadrant)
        {
            foreach (Transform children in spawnPoint)
            {
                Destroy(children.gameObject);
            }
        }
    }

    public void SpawnPowerUp()
    {
        isRoundEnded = false;
        //Invoke("DLSpawnPowerUp", m_StartDelay);
        StartCoroutine(TriggerSpawn(m_StartDelay));
    }

    IEnumerator TriggerSpawn(float delay)
    {
        yield return new WaitForSeconds(delay);

        while (!isRoundEnded)
        {
            float start = Time.time;
            DLSpawnPowerUp();
            yield return new WaitForSeconds(delay - (Time.time - start));
        }
    }

    void SpawnPowerUp(Transform[] spawnPoints, int maxItemCount)
    {
        int spawnCount = Random.Range(0, maxItemCount + 1);
        for (int i = 0; i < spawnCount; i++)
        {
            int spawnPointIndex = Random.Range(0, spawnPoints.Length);


            for (int j = 0; spawnPoints[spawnPointIndex].childCount > 0 && j < spawnPoints.Length; j++)
            {
                spawnPointIndex++;
                spawnPointIndex %= spawnPoints.Length;

                //if no place is left to spawn
                if (j == spawnPoints.Length - 1 && spawnPoints[spawnPointIndex].childCount > 0)
                {
                    return;
                }
            }

            GameObject element = Instantiate(powerUpSpawn, spawnPoints[spawnPointIndex].position, Quaternion.identity);
            element.transform.parent = spawnPoints[spawnPointIndex];
        }
    }

    void DLSpawnPowerUp()
    {
        SpawnPowerUp(loQuadrant, maximumCountOfItemsPerDraw);
        SpawnPowerUp(luQuadrant, maximumCountOfItemsPerDraw);
        SpawnPowerUp(roQuadrant, maximumCountOfItemsPerDraw);
        SpawnPowerUp(ruQuadrant, maximumCountOfItemsPerDraw);
    }

}


