using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    public Animator rockAnimator;
    public GameObject arrow;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnMouseOver()
    {
        Debug.Log("Check");
        arrow.SetActive(true);
    }

    void OnMouseDown()
    {
        if (this.name == "Position1")
        {
            rockAnimator.SetBool("pos1", true);
        }
        else if (this.name == "Position2")
        {
            rockAnimator.SetBool("pos2", true);
        }
        else if (this.name == "Position3")
        {
            rockAnimator.SetBool("pos3", true);
        }
        else if (this.name == "Position4")
        {
            rockAnimator.SetBool("pos4", true);
        }
        else if (this.name == "Position5")
        {
            rockAnimator.SetBool("pos5", true);
        }
    }

    void OnMouseExit()
    {
        Debug.Log("Uncheck");
        arrow.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
