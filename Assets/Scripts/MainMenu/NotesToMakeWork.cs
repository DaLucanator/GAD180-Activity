using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesToMakeWork : MonoBehaviour
{
    /*
     * Reset Time.timescale to 1 after pausing for score screens
     * Reset scores to 0 on any scripts that may adjust it after winning / losing.
     * Increment score using bool as timescale.0 leads to multiple inputs in certain instances
     * wonGame = true; (GameWin())
     * (LevelComplete())
     * if (wonGame)
        {
            CaveLife_GameEvents._playerScore += 1;
            wonGame = false;
        }




    What You Need to HowTo

    public GameObject HowToContainer;
    public bool wonGame = false;




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

    make sure Howto has a refernce
    and how to ok button refences script


















     */

}
