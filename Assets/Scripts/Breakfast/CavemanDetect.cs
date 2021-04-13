using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CavemanDetect : MonoBehaviour
{
    public Animator animator;
    public UnityEvent levelFail;
    public UnityEvent levelPassed;

    public Text GameOverText;
    public Text GameWinText;
    public Button NextLevelBtn;
    public bool wonGame = false;

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
        animator = GetComponent<Animator>();
    }

    public void TriggerTest()
    {
        Debug.Log("Fail");
    }

    public void PassTest()
    {
        Debug.Log("Pass");
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            animator.SetBool("SwitchedSides", true);
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            animator.SetBool("SwitchedSides", false);
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Branch")
        {
            //levelFail.Invoke();
            //Fail
            GameOver();
        }
        else if (other.tag == "Finish")
        {

            //levelPassed.Invoke();
            //Pass
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
