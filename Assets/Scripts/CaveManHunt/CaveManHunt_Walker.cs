using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CaveManHunt_Walker : MonoBehaviour
{
    public GameObject StartPosition;
    public GameObject FirstStop;
    public GameObject SecondStop;
    public GameObject ThirdStop;
    public Text GameOverText;
    public Text GameWinText;
    public Text DinoHealth;
    public Button NextLevelBtn;
    private Rigidbody2D rb;

    private Vector2 startPosition;
    private Vector2 leftPosition;
    public Color red;
    public Color white;

    public bool readyToMoveLeft = true;
    public bool readyToMoveRight = false;
    public bool waitLeft = false;
    public bool waitRight = false;
    public bool movingToStart = false;
    public float dinoHealth = 15f;
    public float dinoSpeed = 8f;

    private void Awake()
    {
        Time.timeScale = 1;
        DinoHealth.text = "" + dinoHealth;

        rb = GetComponent<Rigidbody2D>();
        startPosition = rb.position;
        StartPosition.GetComponent<Collider2D>();
        FirstStop.GetComponent<Collider2D>();
        SecondStop.GetComponent<Collider2D>();
    }

    void Update()
    {
        DinoHealth.text = "" + dinoHealth;
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);
            if (hit.collider != null)
            {
                if (hit.collider.name == "Bush")
                {

                }
                if (hit.collider.name == "Dino1")
                {
                    StartCoroutine(ColourFlash());
                    dinoHealth -= 5f;
                    dinoSpeed *= 2f;
                }
            }
        }

        if (dinoHealth <= 0)
        {
            GameWin();
        }
        else 
        { 
            if (movingToStart && rb.position == startPosition)
            {
                readyToMoveRight = false;
                SetDefaults();
            }
            else
            {
                if (readyToMoveLeft)
                {
                    leftPosition = startPosition;
                    leftPosition.x = startPosition.x - 10f;

                    transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), leftPosition, dinoSpeed * Time.deltaTime);
                }
                else if (readyToMoveRight)
                {
                    transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), startPosition, dinoSpeed * Time.deltaTime);
                }
                else if (waitLeft)
                {
                    StartCoroutine(WaitToBeShotLeft());
                }
                else if (waitRight)
                {
                    StartCoroutine(WaitToBeShotRight());
                }
            }
        }
    }

    IEnumerator WaitToBeShotLeft()
    {
        yield return new WaitForSeconds(0.5f);
        waitLeft = false;
        readyToMoveLeft = true;
        readyToMoveRight = false;
    }
    IEnumerator WaitToBeShotRight()
    {
        yield return new WaitForSeconds(0.5f);
        waitRight = false;
        readyToMoveRight = true;
        readyToMoveLeft = false;
    }

    IEnumerator ColourFlash()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.3f);
        GetComponent<SpriteRenderer>().color = Color.white;
        yield return new WaitForSeconds(0.3f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "FirstStop")
        {
            readyToMoveLeft = false;
            waitLeft = true;
            FirstStop.GetComponent<Collider2D>().enabled = false;
            SecondStop.GetComponent<Collider2D>().enabled = true;
        }

        if (collision.tag == "SecondStop")
        {
            readyToMoveLeft = false;
            waitRight = true;
            SecondStop.GetComponent<Collider2D>().enabled = false;
            ThirdStop.GetComponent<Collider2D>().enabled = true;
        }

        if(collision.tag == "ThirdStop")
        {
            readyToMoveRight = false;
            waitRight = true;
            ThirdStop.GetComponent<Collider2D>().enabled = false;
            movingToStart = true;
        }
    }

    void SetDefaults()
    {
        movingToStart = false;
        readyToMoveRight = false;
        readyToMoveLeft = false;
        waitRight = false;
        FirstStop.GetComponent<Collider2D>().enabled = true;
        StartCoroutine(WaitToBeShotLeft());
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        Cursor.visible = true;
        GameOverText.gameObject.SetActive(true);
        NextLevelBtn.gameObject.SetActive(true);
    }
    public void GameWin()
    {
        Time.timeScale = 0;
        Cursor.visible = true;
        GameWinText.gameObject.SetActive(true);
        NextLevelBtn.gameObject.SetActive(true);
    }
    public void NextLevel()
    {
        Time.timeScale = 1;
        StopAllCoroutines();
        CaveLife_LevelController.OnLevelComplete(1);
    }

}
