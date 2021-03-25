using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GT_PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            rb.MovePosition(transform.position + new Vector3(0,moveSpeed,0) * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            rb.MovePosition(transform.position - new Vector3(0,moveSpeed,0) * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            rb.MovePosition(transform.position - new Vector3(moveSpeed, 0,0) * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            rb.MovePosition(transform.position + new Vector3(moveSpeed, 0,0) * Time.deltaTime);
        }

    }
}
