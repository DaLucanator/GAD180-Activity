using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    public float difficulty = 20f;

    private void Start()
    {
        GetComponent<Rigidbody2D>().gravityScale += Time.timeSinceLevelLoad / difficulty;
    }

    void Update()
    {
        if(transform.position.y < -2f)
        {
            Destroy(gameObject);
        }
    }
}
