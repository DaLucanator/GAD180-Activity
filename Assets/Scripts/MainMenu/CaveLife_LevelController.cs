using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CaveLife_LevelController : MonoBehaviour
{
    public int id;

    void Start()
    {
        CaveLife_GameEvents.current.onLevelComplete += OnLevelComplete;
        Debug.Log(CaveLife_GameEvents.currentScene);
    }

    public static void OnLevelComplete(int id)
    {
        if (id == 1)
        {
            //currentScene variable starts at element 0 initilialised in the Game Events, the list of scenes is not randomised currently as shuffle is not working as expected.

            int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
            if (nextSceneIndex > CaveLife_GameEvents.sceneNumber - 1)
            {
                SceneManager.LoadScene(0);
                Debug.Log("Returned to Main Menu, all Games finished.");
            }
            else
            {
                string nextSceneName = CaveLife_GameEvents.arrayOfScenes[nextSceneIndex];
                SceneManager.LoadScene(nextSceneName);
                CaveLife_GameEvents.currentScene = nextSceneIndex;
            }
        }
    }

}
