using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CaveManEggSave_Controller : MonoBehaviour
{
    [SerializeField] private GameObject _cloudParticlePrefab;

    public float eggHealth = 100f;
    public float moveSpeed = 5f;
    public static float dinosKilled = 0f;

    public Text GameOverText;
    public Text GameWinText;
    public Button NextLevelBtn;

    public Rigidbody2D rb;

    Vector2 movement;

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        if (eggHealth <1)
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
            GameOver();
            dinosKilled = 0f;
        }
        if (dinosKilled > 10)
        {
            Debug.Log("Game Won!");
            GameWin();
            dinosKilled = 0f;
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
