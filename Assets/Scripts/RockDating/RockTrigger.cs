using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RockTrigger : MonoBehaviour
{
    public UnityEvent Failed;
    public UnityEvent Passed;
    public bool failed;
    public Animator explosionAnim;
    public Animator pileAnim;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Fail")
        {
            failed = true;
            StartCoroutine("Delay");
        }
        else if (other.tag == "Pass")
        {
            failed = false;
            StartCoroutine("Delay");
        }
    }
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(2);
        if(failed == true)
        {
            Failed.Invoke();
        }
        else if (failed == false)
        {
            Passed.Invoke();
        }

        yield return null;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
