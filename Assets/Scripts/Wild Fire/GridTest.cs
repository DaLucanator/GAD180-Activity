using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridTest : MonoBehaviour
{
    public Grid grid;
    // Start is called before the first frame update
    void Start()
    {
        grid = new Grid(20, 10, 10f);
        
    }

    
}
