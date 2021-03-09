using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimReset : MonoBehaviour
{
    public Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void ExplosionEnded()
    {
        animator.SetBool("hit", false);
    }
}
