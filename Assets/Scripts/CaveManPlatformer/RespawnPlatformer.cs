
 using UnityEngine;
 using System.Collections;
 
 public class RespawnPlatformer : MonoBehaviour 

{
 
     public Vector2 SpawnPoint;
     
     void OnTriggerEnter (Collider col)
     {
         if     (col.tag == "Player")
         {
             col.transform.position = SpawnPoint;
         }
     }
 }
