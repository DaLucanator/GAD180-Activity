using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CaveManSling_Player : MonoBehaviour
{
    [SerializeField] private float _launchPower = 300;
    [SerializeField] public int currentLives = 3;

    public Text GameOverText;
    public Button NextLevelBtn;
    private Vector3 _startPos;

    private bool _headLaunched;
    private float _idle;
<<<<<<< HEAD
=======
    private float _lives;
>>>>>>> main

    void Awake()
    {
        _startPos = transform.position;
    }

    private void Update()
    {
        GetComponent<LineRenderer>().SetPosition(0, transform.position);
        GetComponent<LineRenderer>().SetPosition(1, _startPos);

        if (_headLaunched && GetComponent<Rigidbody2D>().velocity.magnitude <= 0.1)
        {
            _idle += Time.deltaTime;
        }
        if(transform.position.y > 10 ||
            transform.position.y < -10 ||
            transform.position.x > 10 ||
            transform.position.x < -10 ||
            _idle > 2)
        {


            currentLives -= 1;
            if (currentLives <= 0)
            {
            GameOver();
            }
            else
            {
                int sceneIndex = SceneManager.GetActiveScene().buildIndex;
                SceneManager.LoadScene(sceneIndex);
            }
        }
<<<<<<< HEAD
>>>>>>> MicroGames-Ali
=======
>>>>>>> main
    }

    private void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        GetComponent<LineRenderer>().enabled = true;
    }

    private void OnMouseUp()
    {
        GetComponent<SpriteRenderer>().color = Color.white;
        Vector2 directionToInitialPosition = _startPos - transform.position;
        GetComponent<Rigidbody2D>().AddForce(directionToInitialPosition * _launchPower);
        GetComponent<Rigidbody2D>().gravityScale = 1;
        _headLaunched = true;
        GetComponent<LineRenderer>().enabled = false;
    }

    private void OnMouseDrag()
    {
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(newPosition.x, newPosition.y);
    }
<<<<<<< HEAD

<<<<<<< HEAD
    //Not Active.
    /*
    private void ResetSlingGame()
=======
    public void GameOver()
>>>>>>> MicroGames-Ali
=======
    /*
    public void GameOver()
>>>>>>> main
    {
        GameOverText.gameObject.SetActive(true);
        NextLevelBtn.gameObject.SetActive(true);
    }
    */
    public void GameOver()
    {
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
