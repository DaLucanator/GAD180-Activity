using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeteorShower_PlayerController : MonoBehaviour
{
    public bool isFacingRight = true;
    public float moveSpeed = 10.0f;
    public float direction;
    private SpriteRenderer sprite;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        //Get the Horizontal axis, which by default are mapped to the arrow keys
        //The Value returned is in the range -1 to 1
        float direction = Input.GetAxis("Horizontal");
        float translation = direction * moveSpeed;
        //Make the character move per second, instead of per frame.
        translation *= Time.deltaTime;

        if(direction < 0.0f)
        {
            if (isFacingRight == true)
            {
                transform.Translate(translation, 0, 0);
            }
            else
            {
                isFacingRight = true;
                sprite.flipX = isFacingRight;
                transform.Translate(translation, 0, 0);
            }
        }
        else if (direction > 0.0f)
        {
            if(isFacingRight == true)
            {
                isFacingRight = false;
                sprite.flipX = isFacingRight;
                transform.Translate(translation, 0, 0);
            }
            else
            {
                transform.Translate(translation, 0, 0);
            }

        }

        //Move the character along the x-axis.
        transform.Translate(translation, 0, 0);
    }

    private void Flip()
    {
      

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
