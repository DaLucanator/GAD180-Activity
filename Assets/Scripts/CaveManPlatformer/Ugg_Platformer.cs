using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ugg_Platformer : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpHeight = 5f;
    public bool isJumping = false;

    public Rigidbody2D rb;

    Vector2 movement;



    void Start()
    {
        
    }

    
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");

       if (Input.GetKeyDown (KeyCode.Space))
      {
         if (isJumping == false)
         {
             rb.AddForce(Vector2.up * jumpHeight);
             isJumping = true;
         }
      }
    }

    void FixedUpdate()
    {
           rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "ground")
        {
          isJumping = false;
        }
    }
}
