using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CaveManDodge_ScoreCollider : MonoBehaviour
{
    public float wavesPassed = 0f;
    public float wavesScore = 0f;

    public Text ScoreActual;

    private void Start()
    {
        ScoreActual.text = ("");
    }
    private void FixedUpdate()
    {
        wavesScore = (wavesPassed / 4f);
        ScoreActual.text = ("" + wavesScore);

        if (wavesScore >= 10f)
        {
            FindObjectOfType<CaveManDodgeGameManager>().WinGame();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        wavesPassed++;
    }
}
