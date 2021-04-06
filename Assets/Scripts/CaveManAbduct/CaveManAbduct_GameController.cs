using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CaveManAbduct_GameController : MonoBehaviour
{
    public Text GameOverText;
    public Text GameWinText;
    public Button NextLevelBtn;
    public Text ScoreCount;
    public GameObject HowToContainer;

    public bool wonGame = false;
    public float currentScore = 0f;

    private void Awake()
    {
        Time.timeScale = 0;
        HowToContainer.gameObject.SetActive(true);
    }

    private void Start()
    {
        currentScore = 0f;
        ScoreCount.text = "" + 0f;
    }
    void Update()
    {
        currentScore = CaveManAbduct_Walker.abductionCount;
        ScoreCount.text = "" + currentScore;

        if (currentScore >= 5)
        {
            GameWin();
        }
    }

    public void HowToOk()
    {
        HowToContainer.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        GameOverText.gameObject.SetActive(true);
        NextLevelBtn.gameObject.SetActive(true);
        wonGame = false;
    }
    public void GameWin()
    {
        Time.timeScale = 0;
        GameWinText.gameObject.SetActive(true);
        NextLevelBtn.gameObject.SetActive(true);
        wonGame = true;
    }
    public void NextLevel()
    {
        CaveManAbduct_Walker.abductionCount = 0f;
        currentScore = 0f;
        Time.timeScale = 1;

        if (wonGame)
        {
            CaveLife_GameEvents._playerScore += 1;
            wonGame = false;
        }
        CaveLife_LevelController.OnLevelComplete(1);
    }
}
