using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CaveManAbduct_Walker : MonoBehaviour
{
    [SerializeField]public static float abductionCount = 0f;

    private bool movingLeft = true;
    private bool abducted = false;

    private Vector2 startPosition;
    private Vector2 leftPosition;
    private Vector2 rightPosition;

    public GameObject player;
    private Rigidbody2D rb;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        startPosition = rb.position;
    }

    void FixedUpdate()
    {
        //Abduction not true, patrol you shall.
        if (!abducted)
        {
            if (movingLeft)
            {
                float endPoint = startPosition.x - 2f;

                if (transform.position.x != endPoint)
                {
                    leftPosition = rb.position;
                    leftPosition.x = startPosition.x - 2f;

                    transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), leftPosition, 4f * Time.deltaTime);
                }

                if (transform.position.x == endPoint)
                {
                    movingLeft = false;
                }


            }
            else if (!movingLeft)
            {
                float endPoint = startPosition.x + 2f;

                if (transform.position.x != endPoint)
                {
                    rightPosition = rb.position;
                    rightPosition.x = startPosition.x + 2f;

                    transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), rightPosition, 4f * Time.deltaTime);
                }

                if (transform.position.x == endPoint)
                {
                    movingLeft = true;
                }
            }
        }
        //Abduction is true
        else
        {
            Vector2 ufoPosition = player.transform.position;
            transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), ufoPosition, 4f * Time.deltaTime);

            if(transform.position.y >= 3f)
            {
                Destroy(gameObject);
                abductionCount++;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            abducted = true;
        }
    }
}
