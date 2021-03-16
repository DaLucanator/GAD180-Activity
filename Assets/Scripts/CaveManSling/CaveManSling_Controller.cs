using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CaveManSling_Controller : MonoBehaviour
{
    //private static int _nextLevelIndex = 1;
    public Text GameOverText;
    public Text GameWinText;
    public Button NextLevelBtn;
    private Enemy[] _enemies;

    private void OnEnable()
    {
        _enemies = FindObjectsOfType<Enemy>();
    }

    void Update()
    {
        foreach (Enemy enemy in _enemies)
        {
            if (enemy != null)
            {
                return;
            }
            GameWin();
        }
    }


    public void GameOver()
    {
        GameOverText.gameObject.SetActive(true);
        NextLevelBtn.gameObject.SetActive(true);
        Time.timeScale = 0;
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
