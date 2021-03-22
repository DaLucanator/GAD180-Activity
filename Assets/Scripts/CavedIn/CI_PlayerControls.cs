using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CI_PlayerControls : MonoBehaviour
{
    public bool isFacingRight = true;
    public float moveSpeed = 10.0f;
    private SpriteRenderer sprite;
    private Rigidbody2D rb2D;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        //Get the Horizontal axis, which by default are mapped to the arrow keys
        //The Value returned is in the range -1 to 1
        
        float hDirection = Input.GetAxis("Horizontal");
        float vDirection = Input.GetAxis("Vertical");
        /*
        float hTranslation = hDirection * moveSpeed;
        float vTranslation = vDirection * moveSpeed;
        //Make the character move per second, instead of per frame.
        hTranslation *= Time.deltaTime;
        vTranslation *= Time.deltaTime;
        */

        Vector2 m_Input = new Vector2(hDirection, vDirection);
        Vector2 m_CurrentPos = new Vector2(transform.position.x, transform.position.y);

        if (hDirection < 0.0f || vDirection < 0.0f)
        {
            if (isFacingRight == true)
            {
                rb2D.MovePosition(m_CurrentPos + m_Input * moveSpeed * Time.deltaTime);
                //transform.Translate(hTranslation, vTranslation, 0);
            }
            else
            {
                isFacingRight = true;
                sprite.flipX = isFacingRight;
                rb2D.MovePosition(m_CurrentPos + m_Input * moveSpeed * Time.deltaTime);
                //transform.Translate(hTranslation, vTranslation, 0);
            }
        }
        else if (hDirection > 0.0f || vDirection > 0.0f)
        {
            if (isFacingRight == true)
            {
                isFacingRight = false;
                sprite.flipX = isFacingRight;
                rb2D.MovePosition(m_CurrentPos + m_Input * moveSpeed * Time.deltaTime);
                //transform.Translate(hTranslation, vTranslation, 0);
            }
            else
            {
                rb2D.MovePosition(m_CurrentPos + m_Input * moveSpeed * Time.deltaTime);
                //transform.Translate(hTranslation, vTranslation, 0);
            }

        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Rubble" && Input.GetKeyDown(KeyCode.E))
        {
            RubbleMover rubbleMover = other.gameObject.GetComponent<RubbleMover>();
            rubbleMover.Move();
        }
    }
}
