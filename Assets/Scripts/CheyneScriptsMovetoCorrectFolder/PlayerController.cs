using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator animator;
    private int pos = 3;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void StopMoving()
    {
        
            animator.SetBool("moveLeft", false);
            animator.SetBool("moveRight", false);
         
    }

    // Update is called once per frame
    void Update()
    {
        //I am Going to regret this.
        if(pos == 1)
        {
            if(Input.GetKeyDown(KeyCode.D))
            {
                animator.Play("1to2");
                pos += 1;
            }
        }
        else if (pos == 2)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                animator.Play("2to1");
                pos -= 1;
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                animator.Play("2to3");
                pos += 1;
            }
        }
        else if (pos == 3)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                animator.Play("3to2");
                pos -= 1;
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                animator.Play("3to4");
                pos += 1;
            }
        }
        else if (pos == 4)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                animator.Play("4to3");
                pos -= 1;
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                animator.Play("4to5");
                pos += 1;
            }
        }
        else if (pos == 5)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                animator.Play("5to4");
                pos -= 1;
            }
        }

        /**
        if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            animator.SetBool("moveLeft", true);
            pos -= 1;
        }

        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            animator.SetBool("moveRight", true);
            pos += 1;
        }

        //if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
        //{
         //   animator.SetBool("moveLeft", false);
        //}
        //if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
        //{
         //   animator.SetBool("moveRight", false);
        //}**/


    }
}
