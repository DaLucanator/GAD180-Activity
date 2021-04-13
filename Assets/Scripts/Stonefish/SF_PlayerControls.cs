using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SF_PlayerControls : MonoBehaviour
{
    public Text GameOverText;
    public Text GameWinText;
    public Button NextLevelBtn;

    private int rocksRemaining = 3;
    public int fishHit = 0;
    public GameObject rock;
    public GameObject spawnpoint;
    public GameObject howToWindow;

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

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if(rocksRemaining > 0)
            {
                Instantiate(rock, spawnpoint.transform);
                rocksRemaining -= 1;
            }
            
            

        }
        if(rocksRemaining == 0)
        {
            StartCoroutine("EndGame");
        }
    }
    IEnumerator EndGame()
    {
        yield return new WaitForSeconds(6);
        if(fishHit == 0)
        {
            GameOver();
        }
        else if (fishHit > 0)
        {
            GameWin();
        }
        yield return null;
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
