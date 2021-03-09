using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimController : MonoBehaviour
{
    public int Pos1Remaning = 3;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(Meteors());
    }

    public IEnumerator Meteors()
    {
        yield return new WaitForSeconds(3);
        animator.Play("M1");
        yield return new WaitForSeconds(.5f);
        animator.Play("M2");
        yield return null;
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
