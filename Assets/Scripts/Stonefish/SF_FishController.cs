using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SF_FishController : MonoBehaviour
{
    public SF_PlayerControls levelManagement;
    // Start is called before the first frame update
    void Start()
    {
        levelManagement = GameObject.FindGameObjectWithTag("Player").GetComponent<SF_PlayerControls>();
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Dino")
        {
            levelManagement.fishHit += 1;
            Destroy(other.gameObject);
            Debug.Log("Hit Fish");
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
