using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveManEggSave_Controller : MonoBehaviour
{
    [SerializeField] private GameObject _cloudParticlePrefab;

    public float eggHealth = 100f;
    public float moveSpeed = 5f;

    public Rigidbody2D rb;

    Vector2 movement;


    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Dino")
        {
            Debug.Log("Collision with Dino");
            Instantiate(_cloudParticlePrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        /*
        else if (collision.gameObject.tag == "Egg")
        {
            Debug.Log("Collision with Egg");
            Instantiate(_cloudParticlePrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
            eggHealth -= 10f;
        }
        */
    }
}
