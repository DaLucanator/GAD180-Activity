using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CavemanDetect : MonoBehaviour
{
    public Animator animator;
    public UnityEvent levelFail;
    public UnityEvent levelPassed;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void TriggerTest()
    {
        Debug.Log("Fail");
    }

    public void PassTest()
    {
        Debug.Log("Pass");
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            animator.SetBool("SwitchedSides", true);
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            animator.SetBool("SwitchedSides", false);
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Branch")
        {
            levelFail.Invoke();
        }
        else if (other.tag == "Finish")
        {
            levelPassed.Invoke();
        }

    }
}
