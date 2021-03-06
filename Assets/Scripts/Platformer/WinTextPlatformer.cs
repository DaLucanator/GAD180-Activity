using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinTextPlatformer : MonoBehaviour
{
    public Text GameWinText;
    public Button NextLevelBtn;
    public GameObject HowToContainer;

    public bool wonGame = false;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            //print("You Win");
            GameWin();
        }
    }

    private void Awake()
    {
        Time.timeScale = 0;
        HowToContainer.gameObject.SetActive(true);
    }

    public void HowToOk()
    {
        HowToContainer.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    /*
    public void GameOver()
    {
        Time.timeScale = 0;
        GameOverText.gameObject.SetActive(true);
        NextLevelBtn.gameObject.SetActive(true);
        wonGame = false;
    }
    */

    public void GameWin()
    {
        GameWinText.gameObject.SetActive(true);
        NextLevelBtn.gameObject.SetActive(true);
        wonGame = true;
        Time.timeScale = 0;
    }
    public void NextLevel()
    {
        Time.timeScale = 1;

        if (wonGame)
        {
            CaveLife_GameEvents._playerScore += 1;
            wonGame = false;
        }
        CaveLife_LevelController.OnLevelComplete(1);
    }
}
