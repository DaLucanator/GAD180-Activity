using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class shuffle : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void ShuffleComplete()
    {
        animator.SetBool("ShuffleCompleted", true);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
