using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CI_WinLose : MonoBehaviour
{
    public Text GameOverText;
    public Text GameWinText;
    public Button NextLevelBtn;
    public GameObject HowToContainer;
    public GameObject player;

    public bool wonGame = false;

    private void Awake()
    {
        player.SetActive(false);
        Time.timeScale = 0;
        HowToContainer.gameObject.SetActive(true);
    }

    public void HowToOk()
    {
        HowToContainer.gameObject.SetActive(false);
        player.SetActive(true);
        Time.timeScale = 1;
    }
    //public Button GiveUpBtn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            GameWin();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
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
