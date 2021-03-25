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

    public float currentScore = 0f;
    private void Start()
    {
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
        CaveLife_LevelController.OnLevelComplete(1);
    }
}
