using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CaveManEggSave_Controller : MonoBehaviour
{
    [SerializeField] public static float eggHealth = 100f;

    public float moveSpeed = 5f;
    public static float dinosKilled = 0f;

    public Text GameOverText;
    public Text GameWinText;
    public Button NextLevelBtn;

    public Text DinosStopped;
    public Text EggHealth;

    public Rigidbody2D rb;

    Vector2 movement;

    private void Start()
    {
        DinosStopped.text = "" + 0f;
        EggHealth.text = "" + 100f;
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        EggHealth.text = "" + eggHealth;
        DinosStopped.text = "" + dinosKilled;

        if (eggHealth <1)
        {
            GameOver();
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
