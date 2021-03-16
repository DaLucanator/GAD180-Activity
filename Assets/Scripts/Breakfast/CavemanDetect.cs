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
