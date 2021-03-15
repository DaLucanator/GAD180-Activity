using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CaveManDodgeGameManager : MonoBehaviour
{
    public float slowness = 10f;

    public Text GameOverText;
    public Text GameWinText;
    public Button NextLevelBtn;

    public void EndGame()
    {
        StartCoroutine(GameOver());
    }

    IEnumerator GameOver ()
    {
        Time.timeScale = 1f / slowness;
        Time.fixedDeltaTime = Time.fixedDeltaTime / slowness;

        yield return new WaitForSeconds(1f / slowness);

        GameOverText.gameObject.SetActive(true);
        NextLevelBtn.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void NextLevel()
    {
        CaveLife_LevelController.OnLevelComplete(1);
        Time.timeScale = 1;
    }
}
