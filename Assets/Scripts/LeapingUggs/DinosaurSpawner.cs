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
         Transform spriteTransform = Dinosaur.GetComponentsInChildren<Transform>()[1];

        if (randomIndex > 2)
        {
            Dinosaur.GetComponentInChildren<SpriteRenderer>().flipY = true;
            spriteTransform.localPosition = new Vector3(0, -0.5f, 0);
        }
        else
        {
            Dinosaur.GetComponentInChildren<SpriteRenderer>().flipY = false;
            spriteTransform.localPosition = new Vector3(0, 0.5f, 0);
        }

        Instantiate(Dinosaur, spawnPoint.position, spawnPoint.rotation);


    }

}
