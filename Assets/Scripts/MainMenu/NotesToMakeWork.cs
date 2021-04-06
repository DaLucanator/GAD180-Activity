using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesToMakeWork : MonoBehaviour
{
    /*
     * Reset Time.timescale to 1 after pausing for score screens
     * Reset scores to 0 on any scripts that may adjust it after winning / losing.
     * Increment score using bool as timescale.0 leads to multiple inputs in certain instances
     * wonGame = true; (GameWin())
     * (LevelComplete())
     * if (wonGame)
        {
            CaveLife_GameEvents._playerScore += 1;
            wonGame = false;
        }
     */

}
