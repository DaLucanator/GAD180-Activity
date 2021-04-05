using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveManDodge_Player : MonoBehaviour
{
    public float speed = 15f;
    public float mapWidth = 7.5f;

    private Rigidbody2D rb;

    public GameObject HowToContainer;

    private void Awake()
    {
        Time.timeScale = 0;
        HowToContainer.gameObject.SetActive(true);
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal") * Time.fixedDeltaTime * speed;

        Vector2 newPosition = rb.position + Vector2.right * x;
        newPosition.x = Mathf.Clamp(newPosition.x, -mapWidth, mapWidth);

        rb.MovePosition(newPosition);
    }
    public void HowToOk()
    {
        HowToContainer.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    private void OnCollisionEnter2D()
    {
        FindObjectOfType<CaveManDodgeGameManager>().EndGame();
    }
}
