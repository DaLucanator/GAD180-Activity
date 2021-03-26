using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CaveManSling_Controller : MonoBehaviour
{
    //private static int _nextLevelIndex = 1;
    
    public Text GameWinText;
    public Button NextLevelBtn;
    private Enemy[] _enemies;

    private void Awake()
    {
        Time.timeScale = 1;
    }
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
