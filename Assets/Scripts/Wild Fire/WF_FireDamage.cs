using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WF_FireDamage : MonoBehaviour
{
    public WF_PlayerController controller;
    // Start is called before the first frame update

    public void Start()
    {
        controller = GameObject.FindGameObjectWithTag("Player").GetComponent<WF_PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            controller.GameOver();
        }
    }
    
}
