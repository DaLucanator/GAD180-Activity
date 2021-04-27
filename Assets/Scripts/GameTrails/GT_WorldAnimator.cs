using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GT_WorldAnimator : MonoBehaviour
{
    #region LevelLoader
    //Level Loader Variables and Functions
    public Text GameOverText;
    public Text GameWinText;
    public Button NextLevelBtn;
    public bool wonGame = false;


    public void GameOver()
    {
        Time.timeScale = 0;
        worldCanvas.SetActive(false);
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
        else { wonGame = false; }
        CaveLife_LevelController.OnLevelComplete(1);
    }
    #endregion

    //Game variables
    public GameObject player;
    public GameObject[] cows;
    public GameObject worldCanvas;
    private Animator animator;
    public GameObject howToWindow;

    public void Awake()
    {
        Time.timeScale = 0;
        howToWindow.SetActive(true);
        worldCanvas.SetActive(false);
    }

    public void HowToOk()
    {
        worldCanvas.SetActive(true);
        howToWindow.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
    // Start is called before the first frame update
    void Start()
    {
        animator = this.gameObject.GetComponent<Animator>();
    }

    public void ActivatePlayer()
    {
        player.SetActive(true);
    }


    void DeActivateCows()
    {
        foreach (GameObject cow in cows)
        {
            cow.SetActive(false);
        }
    }

    public void PanWorldUp1()
    {
        animator.SetBool("PanUp1", true);

    }

    public void PanWorldUp2()
    {
        animator.SetBool("PanUp2", true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
