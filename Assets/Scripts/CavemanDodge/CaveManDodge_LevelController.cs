using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveManDodge_LevelController : MonoBehaviour
{
    private Enemy[] _enemies;

    private void OnEnable()
    {
        _enemies = FindObjectsOfType<Enemy>();
    }

    void Update()
    {
        foreach(Enemy enemy in _enemies)
        {
            if (enemy != null)
                return;
        }
        Debug.Log("All Enemies Dead.");
    }
}
