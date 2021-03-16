using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyUggPlayer : MonoBehaviour
{
    Rigidbody2D rb;
    public float jumpForce;
    public float moveSpeed;
    Vector2 moveForward;
    bool canGoForward = true;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        Jump();

        if (canGoForward) 
        { 
             moveForward = gameObject.transform.position;
             moveForward.x += 0.1f * moveSpeed;
             gameObject.transform.position = moveForward;  
        }
    }

    

    void Jump() 
    { 
        if (Input.GetKeyDown(KeyCode.Space)) 
       { 
        rb.velocity = new Vector2(rb.velocity.x, jumpForce); 
       } 
    }

}
