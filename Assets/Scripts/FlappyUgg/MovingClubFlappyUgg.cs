using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingClubFlappyUgg : MonoBehaviour
{
    public float dirY, moveSpeed = 3f;
    bool moveDown = true;

    void Update()
    {
        if (transform.position.y > 0f)
            moveDown = false;
        if (transform.position.y < -6f)
            moveDown = true;

        if (moveDown)
            transform.position = new Vector2(transform.position.y + moveSpeed * Time.deltaTime, transform.position.x);
        else
            transform.position = new Vector2(transform.position.y - moveSpeed * Time.deltaTime, transform.position.x);
    }
}