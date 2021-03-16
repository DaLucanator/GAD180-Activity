using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CaveLife_GameEvents : MonoBehaviour
{
    public static CaveLife_GameEvents current;
    public static string[] arrayOfScenes;
    public static int sceneNumber;
    public static string[] arrayOfUsedScenes;
    public static int currentScene;

    public Button Btn_Start;
    public Button Btn_HighScore;

    private void Awake()
    {
        current = this;

        currentScene = SceneManager.GetActiveScene().buildIndex;

        sceneNumber = SceneManager.sceneCountInBuildSettings;
        arrayOfScenes = new string[sceneNumber];

        //Starts at 1 to skip menu scene;
        for (int i = 1; i < sceneNumber; i++)
        {
            arrayOfScenes[i] = Path.GetFileNameWithoutExtension(SceneUtility.GetScenePathByBuildIndex(i));
            //Shuffle(arrayOfScenes);
        }
    }

    public event Action<int> onLevelComplete;
    public void LevelComplete(int id)
    {
        if (onLevelComplete != null)
        {
            onLevelComplete(id);
        }
    }

    public void CaveLifeStart()
    {
        SceneManager.LoadScene(1);
    }

    //TODO

    //Randomise Scene Array Order
    /*
    public void Shuffle()
    {
        for (int i = 0; i < arrayOfScenes.Length; i++)
        {
            int rand = UnityEngine.Random.Range(i,arrayOfScenes.Length);
            string tempGO = arrayOfScenes[rand];
            arrayOfScenes[rand] = arrayOfScenes[i];
            arrayOfScenes[i] = tempGO;
        }
    }
    */

    /*
    void Shuffle(string[] texts)
    {
        // Knuth shuffle algorithm :: courtesy of Wikipedia :)
        for (int t = 0; t < texts.Length; t++)
        {
            string tmp = texts[t];
            int r = UnityEngine.Random.Range(t, texts.Length);
            texts[t] = texts[r];
            texts[r] = tmp;
        }
    }
    */
}
