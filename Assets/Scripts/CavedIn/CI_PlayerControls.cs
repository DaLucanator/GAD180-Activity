using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CI_PlayerControls : MonoBehaviour
{
    public bool isFacingRight = true;
    public float moveSpeed = 10.0f;
    private SpriteRenderer sprite;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        //Get the Horizontal axis, which by default are mapped to the arrow keys
        //The Value returned is in the range -1 to 1
        float hDirection = Input.GetAxis("Horizontal");
        float vDirection = Input.GetAxis("Vertical");
        float hTranslation = hDirection * moveSpeed;
        float vTranslation = vDirection * moveSpeed;
        //Make the character move per second, instead of per frame.
        hTranslation *= Time.deltaTime;
        vTranslation *= Time.deltaTime;

        if (hDirection < 0.0f || vDirection < 0.0f)
        {
            if (isFacingRight == true)
            {
                transform.Translate(hTranslation, vTranslation, 0);
            }
            else
            {
                isFacingRight = true;
                sprite.flipX = isFacingRight;
                transform.Translate(hTranslation, vTranslation, 0);
            }
        }
        else if (hDirection > 0.0f || vDirection > 0.0f)
        {
            if (isFacingRight == true)
            {
                isFacingRight = false;
                sprite.flipX = isFacingRight;
                transform.Translate(hTranslation, vTranslation, 0);
            }
            else
            {
                transform.Translate(hTranslation, vTranslation, 0);
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
