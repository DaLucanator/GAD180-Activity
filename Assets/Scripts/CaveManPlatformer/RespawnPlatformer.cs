
 using UnityEngine;
 using System.Collections;
 using UnityEngine.UI;

public class RespawnPlatformer : MonoBehaviour 

{
    public Text GameOverText;
    public Button NextLevelBtn;
    public Vector2 SpawnPoint;


    void OnTriggerEnter2D (Collider2D collision)
     {
         if     (collision.tag == "Player")
         {
            //col.transform.position = SpawnPoint;
            GameOver();
         }
     }

    public void GameOver()
    {
        GameOverText.gameObject.SetActive(true);
        NextLevelBtn.gameObject.SetActive(true);
        GetComponent<Rigidbody2D>().gravityScale = 0;
        Time.timeScale = 0;
    }
}
