using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartShuffle : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Shuffle()
    {
        animator.SetBool("start", true);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
