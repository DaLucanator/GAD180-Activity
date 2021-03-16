using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinText : MonoBehaviour
{
    public Text GameWinText;
    public Button NextLevelBtn;

    void OnTriggerEnter2D (Collider2D col)
     {
         if     (col.tag == "Player")
         {
             //print("You Win");
            GameWin();
         }
     }

    public void GameWin()
    {
        GameWinText.gameObject.SetActive(true);
        NextLevelBtn.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
    public void NextLevel()
    {
        CaveLife_LevelController.OnLevelComplete(1);
        Time.timeScale = 1;
    }
}
