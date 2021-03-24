using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WF_FireController : MonoBehaviour
{

    
    public GameObject fire;

    public WF_FireController S_north;
    public WF_FireController S_east;
    public WF_FireController S_south;
    public WF_FireController S_west;

    public bool onFire = false;
    public float fuel = 10f;
    public float temp;
    public float maxTemp = 15f;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (temp >= maxTemp)
        {
            StartFire();
        }

        if (onFire == true)
        {
            fuel -= 2f * Time.deltaTime;

            if (S_north != null)
            {
                S_north.temp += 10 * Time.deltaTime;
            }
            if (S_east != null)
            {
                S_east.temp += 10 * Time.deltaTime;
            }
            if (S_south != null)
            {
                S_south.temp += 10 * Time.deltaTime;
            }
            if (S_west != null)
            {
                S_west.temp += 10 * Time.deltaTime;
            }

            if (fuel <= 0)
            {
                StopFire();
            }
        }
    }

    private void StopFire()
    {
        fire.SetActive(false);
        onFire = false;
    }

    public void StartFire()
    {
        fire.SetActive(true);
        onFire = true;
    }
}
