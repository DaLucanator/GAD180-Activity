using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CavemanAnimationController : MonoBehaviour
{
    private Animator animator;
    public GameObject world;
    private Animator worldAnimator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        world = GameObject.FindGameObjectWithTag("Environment");
        worldAnimator = world.GetComponent<Animator>();
    }

    public void StartClimb()
    {
        worldAnimator.SetBool("ClimbStarted", true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
