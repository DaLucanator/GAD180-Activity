using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UggHexTimer : MonoBehaviour
{

     float TmStart;
     float TmLen=10f;
 
     // Use this for initialization
     void Start () {
         TmStart=Time.time;
     }
     
     // Update is called once per frame
     void Update () {
         if(Time.time>TmStart + TmLen) 
         {
 
             Debug.Log("You Win");
         }
     }
}
