using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    //Start Variables

    private Vector3 _startPos;
    private bool _headLaunched;
    private float _idle;

    [SerializeField] private float _launchPower = 300;

    //End Variables

    void Awake()
    {
        //get start pos
        _startPos = transform.position;
    }

    private void Update()
    {
        //Set Line to go from head to start position
        GetComponent<LineRenderer>().SetPosition(0, transform.position);
        GetComponent<LineRenderer>().SetPosition(1, _startPos);

        if (_headLaunched && GetComponent<Rigidbody2D>().velocity.magnitude <= 0.1)
        {
            _idle += Time.deltaTime;
        }

        //reset bird position if flys too far.
        if(transform.position.y > 10 ||
            transform.position.y < -10 ||
            transform.position.x > 10 ||
            transform.position.x < -10 ||
            _idle > 2)
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }
    }

    private void OnMouseDown()
    {
        //mouse click and hold highlights head in red
        GetComponent<SpriteRenderer>().color = Color.red;
        GetComponent<LineRenderer>().enabled = true;
    }

    private void OnMouseUp()
    {
        //mouse release returns head colour back to default, white.
        GetComponent<SpriteRenderer>().color = Color.white;


        //Add force to fire head. Direction is from current mouse pos to star pos.
        //Force Multiplier variable _launchPower, gravity scale 1.
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



}
