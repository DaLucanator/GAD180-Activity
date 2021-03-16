using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathClubFlappyUgg : MonoBehaviour
{
   public Vector2 SpawnPoint;

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    void OnTriggerEnter2D (Collider2D col)
     {
         if     (col.tag == "Player")
         {
             col.transform.position = SpawnPoint;
         }
     }
}
