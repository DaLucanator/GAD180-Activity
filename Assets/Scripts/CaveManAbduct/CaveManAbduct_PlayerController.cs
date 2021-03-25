using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveManAbduct_PlayerController : MonoBehaviour
{
    Vector2 movement;
    BoxCollider2D beamCollider;

    public Rigidbody2D rb;

    private float speed = 15f;
    private float mapWidth = 7.25f;

    void Start()
    {
        beamCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            beamCollider.enabled = true;
            Debug.Log("Collider enabled ");
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            beamCollider.enabled = false;
            Debug.Log("Collider disabled ");
        }
    }

    void FixedUpdate()
    {
        movement.x = Input.GetAxisRaw("Horizontal");

        float x = Input.GetAxis("Horizontal") * Time.fixedDeltaTime * speed;

        Vector2 newPosition = rb.position + Vector2.right * x;

        newPosition.x = Mathf.Clamp(newPosition.x, -mapWidth, mapWidth);

        rb.MovePosition(newPosition);
    }
}
