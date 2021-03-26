using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveManHunt_Reticle : MonoBehaviour
{

    void Awake()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePos;
    }
}
