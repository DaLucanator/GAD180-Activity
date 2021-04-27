using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MeteorControllerScript : MonoBehaviour
{
    private int meteorCount = 0;
    public int previousSpawnpoint = 0;
    public float meteorDelay = 1.0f;
    public GameObject[] spawnPoints;
    public GameObject meteor;
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
        StartCoroutine("MeteorSpawner");
    }

    IEnumerator MeteorSpawner()
    {
        yield return new WaitForSeconds(meteorDelay);
        int spawnpoint = Random.Range(0, 5);
        
        while(spawnpoint == previousSpawnpoint)
        {
            spawnpoint = Random.Range(0, 5);
        }
        Instantiate(meteor, spawnPoints[spawnpoint].transform);
        meteorCount += 1;
        previousSpawnpoint = spawnpoint;
        StartCoroutine("MeteorSpawner");
        yield return null;
    }

    // Update is called once per frame
    void Update()
    {
        if(meteorCount >= 10)
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
