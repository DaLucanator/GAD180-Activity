using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CaveManDodgeGameManager : MonoBehaviour
{
    public float slowness = 10f;
    public float x;

    public Text GameOverText;
    public Text GameWinText;
    public Button NextLevelBtn;

    public void EndGame()
    {
        StartCoroutine(GameOver());
    }

    public void WinGame()
    {
        StartCoroutine(GameWon());
    }

    IEnumerator GameOver()
    {
        Time.timeScale = 1f / slowness;
        x = Time.fixedDeltaTime;
        Time.fixedDeltaTime /= slowness;

        yield return new WaitForSeconds(1f / slowness);

        GameOverText.gameObject.SetActive(true);
        NextLevelBtn.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    IEnumerator GameWon()
    {
        Time.timeScale = 1f / slowness;
        x = Time.fixedDeltaTime;
        Time.fixedDeltaTime /= slowness;

        yield return new WaitForSeconds(1f / slowness);

        GameWinText.gameObject.SetActive(true);
        NextLevelBtn.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void NextLevel()
    {
        Time.fixedDeltaTime = x;
        Time.timeScale = 1;
        CaveLife_LevelController.OnLevelComplete(1);
    }
}
