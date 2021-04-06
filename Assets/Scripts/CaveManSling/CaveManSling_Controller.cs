using UnityEngine;
using UnityEngine.UI;

public class CaveManSling_Controller : MonoBehaviour
{
    public Text GameWinText;
    public Button NextLevelBtn;
    private Enemy[] _enemies;

    public bool wonGame = false;

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
