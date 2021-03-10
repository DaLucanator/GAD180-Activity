using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;

    public GameObject dinoPrefab;

    public float timeBetweenWaves = 1f;

    private float timeToSpawn = 2f;

    void Update()
    {
        if (Time.time >= timeToSpawn)
        {
            SpawnDinos();
            timeToSpawn = Time.time + timeBetweenWaves;
        }
    }

    void SpawnDinos()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);

        for (int i = 0; i < spawnPoints.Length; i++)
        {
            if (randomIndex == i)
            {
                Instantiate(dinoPrefab, spawnPoints[i].position, Quaternion.identity);
            }
        }
    }
}
