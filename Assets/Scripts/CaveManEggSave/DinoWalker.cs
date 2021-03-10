using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoWalker : MonoBehaviour
{
    [SerializeField] private GameObject _cloudParticlePrefab;
    public float eggHealth = 100f;

    public Vector2 eggPosition = new Vector2(0, 0);
    void Update()
    {
        transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), eggPosition, 3 * Time.deltaTime);
    }
}
