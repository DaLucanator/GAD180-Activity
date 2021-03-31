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
    #endregion

//Game variables
    public GameObject player;
    public GameObject[] cows;
    private Animator animator;
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
