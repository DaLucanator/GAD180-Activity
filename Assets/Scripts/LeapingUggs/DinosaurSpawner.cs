using UnityEngine;

public class DinosaurSpawner : MonoBehaviour
{

      public float spawnDelay = 3f;

      public GameObject Dinosaur;

      public Transform[] spawnPoints;

      public float nextTimeToSpawn = 0f;

    void Update ()
    {
        if (nextTimeToSpawn <= Time.time)
        {
             SpawnDinosaur();
             nextTimeToSpawn = Time.time + spawnDelay;
        }
    }  

   
    void SpawnDinosaur ()
    {
         int randomIndex = Random.Range(0, spawnPoints.Length);
         Transform spawnPoint = spawnPoints[randomIndex];

         Instantiate(Dinosaur, spawnPoint.position, spawnPoint.rotation);
    }

}
