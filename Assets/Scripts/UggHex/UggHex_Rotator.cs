using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UggHex_Rotator : MonoBehaviour
{
    
    void Start()
    {
        
    }
    
    void Update()
    {
        transform.Rotate(Vector3.forward, Time.deltaTime * 30f);
    }
}