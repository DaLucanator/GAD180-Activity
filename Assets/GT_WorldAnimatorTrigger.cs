using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GT_WorldAnimatorTrigger : MonoBehaviour
{
    public GT_WorldAnimator worldAnimator;

    public bool trigger1 = false;
    public bool trigger2 = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (trigger1 == true)
            {
                worldAnimator.PanWorldUp1();
            }
            else if(trigger2 == true)
            {
                worldAnimator.PanWorldUp2();
            }
        }
    }
}
