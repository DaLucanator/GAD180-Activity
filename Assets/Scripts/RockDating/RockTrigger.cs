using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class RockTrigger : MonoBehaviour
{

    public Text GameOverText;
    public Text GameWinText;
    public Button NextLevelBtn;
    public GameObject howToWindow;
    public bool wonGame;

    public void Awake()
    {
        Time.timeScale = 0;
        howToWindow.SetActive(true);
    }

    public void HowToOk()
    {
        howToWindow.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "GameOver")
        {
            GameOver();
        }
        else if (other.tag == "GameWin")
        {
            GameWin();
        }
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
    }
}
