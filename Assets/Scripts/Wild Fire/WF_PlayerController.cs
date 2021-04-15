using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WF_PlayerController : MonoBehaviour
{
    public Text GameOverText;
    public Text GameWinText;
    public Button NextLevelBtn;
    public GameObject howToWindow;
    public bool wonGame = false;
    public SpriteRenderer playerSprite;
    public void Awake()
    {
        playerSprite = this.GetComponent < SpriteRenderer >();
        playerSprite.enabled = false;
        Time.timeScale = 0;
        howToWindow.SetActive(true);
    }

    public void HowToOk()
    {
        howToWindow.gameObject.SetActive(false);
        playerSprite.enabled = true;
        Time.timeScale = 1;
    }

    float _spdForce = 100f;
    float _trqForce = -200f;
    float _drftForce;
    float _drftForceSticky = 0.1f;
    float _drftForceSlippy = 0.999f;
    float maxStickVelocity = 2.5f;
    float minSlippyVelocity = 1.5f;
    float _trqForceAdjuster;

    void Start()
    {
        StartCoroutine("GameTime");
    }

    void FixedUpdate()
    {
        Rigidbody2D _rb = GetComponent<Rigidbody2D>();

        _drftForce = _drftForceSticky;

        if (RightVelocity().magnitude > maxStickVelocity)
        {
            _drftForce = _drftForceSlippy;
        }
        if (RightVelocity().magnitude < minSlippyVelocity)
        {
            _drftForce = _drftForceSticky;
        }
            _rb.velocity = ForwardVelocity() + RightVelocity() * _drftForceSlippy;

        if (Input.GetKey(KeyCode.W))
        {
            _rb.AddForce(transform.up * _spdForce);
        }

        _trqForceAdjuster = Mathf.Lerp(0, _trqForce, _rb.velocity.magnitude / 2);

        _rb.angularVelocity = Input.GetAxis("Horizontal") * _trqForceAdjuster;

        if(Input.GetKey(KeyCode.Z))
        {
            _rb.velocity = new Vector2(0f, 0f);
            Time.timeScale = 5;
        }

    }

    IEnumerator GameTime()
    {
        yield return new WaitForSeconds(30);
        GameWin();
        //yield return null;
    }
    Vector2 ForwardVelocity()
    {
        return transform.up * Vector2.Dot(GetComponent<Rigidbody2D>().velocity, transform.up);
    }
    Vector2 RightVelocity()
    {
        return transform.right * Vector2.Dot(GetComponent<Rigidbody2D>().velocity, transform.right);
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
