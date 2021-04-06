using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceCarFlip : MonoBehaviour
{
    Vector3 trans;

    void Update()
    {
        if (this.gameObject.transform.eulerAngles.z < 180f)
        {
            this.GetComponent<SpriteRenderer>().flipX = true;
            trans.x = 0.5f;
            Flip();
        }
        else
        {
            this.GetComponent<SpriteRenderer>().flipX = false;
            trans.x = -0.5f;
            Flip();
        }
    }

    void Flip()
    {
        transform.localPosition = trans;
    }
}

// luc made this code

