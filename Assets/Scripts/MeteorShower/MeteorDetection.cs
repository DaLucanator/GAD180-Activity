using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MeteorDetection : MonoBehaviour
{
    public MeteorControllerScript meteorController;

    private void Awake()
    {
        meteorController = GetComponentInParent<MeteorControllerScript>();
    }
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "ground")
        {
            Destroy(this.gameObject);
        }
        else if (other.tag == "Player")
        {
            meteorController.GameOver();
        }
    }

    
}
