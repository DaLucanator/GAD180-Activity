using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UggHexManager : MonoBehaviour
{

    public static bool loseGame = false;
    public static bool timerWin = false;
    public GameObject HowToContainer;
    public bool wonGame = false;
    public Text GameOverText;
    public Text GameWinText;
    public Button NextLevelBtn;

    private void Awake()
    {
        Time.timeScale = 0;
        HowToContainer.gameObject.SetActive(true);
    }


    private void Update()
    {
        if (loseGame)
        {
            GameOver();
        }
        if (timerWin)
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

        Time.timeScale = 1;

        if (wonGame)
        {
            CaveLife_GameEvents._playerScore += 1;
            wonGame = false;
        }
        CaveLife_LevelController.OnLevelComplete(1);
        loseGame = false;
        timerWin = false;
    }





















}
