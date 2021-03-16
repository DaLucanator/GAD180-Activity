﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CaveManSling_Player : MonoBehaviour
{
    [SerializeField] private float _launchPower = 300;

    private Vector3 _startPos;
    private bool _headLaunched;
    private float _idle;
    private float _lives;
    public Button NextLevelBtn;
    public Text GameOverText;

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
            //ResetSlingGame();
            //SceneManager.LoadScene(1);
            /*
            _lives++;
                if(_lives == 3)
        {
                CaveManSling_Player.GameOver();
        }
            */
            GameOver();
      }
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

    //Not Active.
    /*
    private void ResetSlingGame()
    {
        GetComponent<Rigidbody2D>().gravityScale = 0;
        transform.position = _startPos;
        _headLaunched = false;
        _idle = 0f;
        transform.rotation = Quaternion.Euler(0, 0, 0);
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
