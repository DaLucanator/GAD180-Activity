using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UggPlatformer : MonoBehaviour
{
	Rigidbody2D rb;
	public float jumpForce;
	public float speed;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
    }

    
    void Update()
    {
	Move();
	Jump();
    }

    void Jump()
    {
	if (Input.GetKeyDown(KeyCode.Space)) 
        { 
        rb.velocity = new Vector2(rb.velocity.x, jumpForce); 
        } 
    }

    void Move() 
    { 
	float x = Input.GetAxisRaw("Horizontal"); 
	float moveBy = x * speed; 
	rb.velocity = new Vector2(moveBy, rb.velocity.y); 
    }


}






/* Saved Old Script


{
    public float moveSpeed = 5f;
    public float jumpHeight = 100f;
    public bool isJumping = false;

    public Rigidbody2D rb;

    Vector2 movement;



    void Start()
    {
        
    }

    
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");

 	rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

       if (Input.GetKeyDown (KeyCode.Space))
      {
         if (isJumping == false)
         {
             rb.AddForce(Vector2.up * jumpHeight);
             isJumping = true;
         }
      }
    }


    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "ground")
        {
          isJumping = false;
        }
    }
}
*/