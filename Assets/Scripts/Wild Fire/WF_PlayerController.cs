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


    }

    IEnumerator GameTime()
    {
        yield return new WaitForSeconds(30);
        GameWin();
        yield return null;
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
