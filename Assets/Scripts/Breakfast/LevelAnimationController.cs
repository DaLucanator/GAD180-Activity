using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelAnimationController : MonoBehaviour
{
    public Animator animator;
    public Animator playerAnimator;
    public GameObject player;
    public GameObject environmentGroup;
    // Start is called before the first frame update
    void Start()
    {
        environmentGroup = this.gameObject;
        player = GameObject.FindGameObjectWithTag("Player");
        playerAnimator = player.GetComponent<Animator>();
        animator = GetComponent<Animator>();
    }

    public void StartLevel()
    {
        playerAnimator.SetBool("IsGrounded", true);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
