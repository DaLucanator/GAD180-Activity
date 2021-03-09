using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterContestant : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void MoveSprite()
    {
        animator.SetBool("enter", true);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
