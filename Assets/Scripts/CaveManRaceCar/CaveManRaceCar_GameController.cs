using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CaveManRaceCar_GameController : MonoBehaviour
{
    public Text GameOverText;
    public Text GameWinText;
    public Button NextLevelBtn;
    public Text scoreObject;
    public GameObject raceCar;

    public Vector2 forwardSpeed;

    public bool onTrack = false;
    public float scoreValue = 0f;
    private float scoreTimer = 0f;
    public float scoreTimerTarget = 2f;

    void Start()
    {
        Time.timeScale = 1;
        scoreObject.text = "";
    }

    void Update()
    {
        Rigidbody2D _rb = raceCar.GetComponent<Rigidbody2D>();
        scoreObject.text = "" + scoreValue;
        if (onTrack && ForwardVelocity().magnitude > 1)
        {
            scoreTimer += Time.deltaTime;
            if (scoreTimer >= scoreTimerTarget)
            {
                scoreValue = scoreValue + 1;
                scoreTimer = 0f;
            }
        }
        else
        {
            scoreTimer = 0f;
        }
        if(scoreValue >= 10)
        {
            GameWin();
        }
    }

    public Vector2 ForwardVelocity()
    {
        return transform.up * Vector2.Dot(raceCar.GetComponent<Rigidbody2D>().velocity, transform.up);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        onTrack = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        onTrack = false;
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        GameOverText.gameObject.SetActive(true);
        NextLevelBtn.gameObject.SetActive(true);
    }
    public void GameWin()
    {
        Time.timeScale = 0;
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
