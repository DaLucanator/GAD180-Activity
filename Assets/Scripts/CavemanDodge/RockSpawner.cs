using UnityEngine;

public class RockSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;

    public GameObject rockPrefab;

    public float timeBetweenWaves = 1f;

    private float timeToSpawn = 2f;

    void Update()
    {
        if(Time.time >= timeToSpawn)
        {
            SpawnRocks();
            timeToSpawn = Time.time + timeBetweenWaves;
        }
        


    }

     void SpawnRocks()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);

        for (int i = 0; i < spawnPoints.Length; i++)
        {
            if (randomIndex != i)
            {
                Instantiate(rockPrefab, spawnPoints[i].position, Quaternion.identity);
            }
        }
    }
}
