using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixPosition : MonoBehaviour
{
    public bool boop;

    // this script sets the position of flipped objects so that the sprite lines up correctly with the road
    private void Update()
    {
        if (GetComponent<SpriteRenderer>().flipY == true)
        {
            boop = true;
            transform.localPosition.Set(0, -0.5f, 0);
        }
        else
        {
            transform.localPosition.Set(0, 0.5f, 0);
        }
    }
}
