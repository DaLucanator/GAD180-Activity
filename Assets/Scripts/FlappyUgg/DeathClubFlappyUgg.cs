using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathClubFlappyUgg : MonoBehaviour
{
    
    public Vector2 SpawnPoint;
    public Text GameOverText;
    public Button NextLevelBtn;


    public void GameOver()
    {
        GameOverText.gameObject.SetActive(true);
        NextLevelBtn.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void NextLevel()
    {
        CaveLife_LevelController.OnLevelComplete(1);
        Time.timeScale = 1;
    }

    void OnTriggerEnter2D (Collider2D col)
     {
         if     (col.tag == "Player")
         {
            GameOver();
        }
     }
}
