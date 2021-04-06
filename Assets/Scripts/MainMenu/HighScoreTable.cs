using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreTable : MonoBehaviour
{
    public int totalTopScores = 10;
    bool _listDestroyed = false;

    private Transform entryContainer;
    private Transform entryTemplate;
    private List<Transform> highscoreEntryTransformList;

    public Button Btn_ClearScores;

    void Awake()
    {
        entryContainer = transform.Find("HighScoreEntryContainer");
        entryTemplate = entryContainer.Find("HighScoreEntryTemplate");

        entryTemplate.gameObject.SetActive(false);

        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        SortAndAddDummy();
    }

public void SortAndAddDummy()
    {
        //Sort
        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        for (int i = 0; i < highscores.highscoreEntryList.Count; i++)
        {
            for (int j = i + 1; j < highscores.highscoreEntryList.Count; j++)
            {
                if (highscores.highscoreEntryList[j].score > highscores.highscoreEntryList[i].score)
                {
                    HighscoreEntry temp = highscores.highscoreEntryList[i];
                    highscores.highscoreEntryList[i] = highscores.highscoreEntryList[j];
                    highscores.highscoreEntryList[j] = temp;
                }
            }
        }
        //Add
        highscoreEntryTransformList = new List<Transform>();
        for (int i = 0; i < totalTopScores; i++)
        {
            if (i < highscores.highscoreEntryList.Count)
            {
                HighscoreEntry highscoreEntry = highscores.highscoreEntryList[i];
                CreateHighscoreEntryTransform(highscoreEntry, entryContainer, highscoreEntryTransformList);
            }
            else
            {
                AddHighscoreEntry(0, "AAA");
            }
        }

        if(_listDestroyed == true)
        {
            highscoreEntryTransformList = new List<Transform>();
            for (int i = 0; i < totalTopScores; i++)
            {
                if (i < highscores.highscoreEntryList.Count)
                {
                    HighscoreEntry highscoreEntry = highscores.highscoreEntryList[i];
                    CreateHighscoreEntryTransform(highscoreEntry, entryContainer, highscoreEntryTransformList);
                }
                else
                {
                    AddHighscoreEntry(0, "AAA");
                }
            }
            _listDestroyed = false;
        }
    }

    public void ClearScores()
    {
        /*
        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);
        highscores.highscoreEntryList.Clear();
        SortAndAddDummy();
        SaveScores();
        */
        /*
        if (highscoreEntryTransformList.Count < 1)
        {
            Debug.Log("I ran");
        }
        else
        {
        */
        for (int i = 0; i < highscoreEntryTransformList.Count; i++)
            {
                Destroy(highscoreEntryTransformList[i].gameObject);
                _listDestroyed = true;
            }

        //SortandAddDummy should recreate them but doesnt ?
        SortAndAddDummy();
        SaveScores();
    }

    public static void SaveScores()
    {
        //string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = new Highscores();
        //Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        //Save updated Highscores
        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscoreTable", json);
        PlayerPrefs.Save();
    }

    private void CreateHighscoreEntryTransform(HighscoreEntry highscoreEntry, Transform container, List<Transform> transformList)
    {
        float templateHeight = 30f;
        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
        entryTransform.gameObject.SetActive(true);

        int rank = transformList.Count + 1;
        string rankString;
        switch (rank)
        {
            default:
                rankString = rank + "TH"; break;

            case 1: rankString = "1ST"; break;
            case 2: rankString = "2ND"; break;
            case 3: rankString = "3RD"; break;
        }

        entryTransform.Find("PosText").GetComponent<Text>().text = rankString;

        int score = highscoreEntry.score;
        entryTransform.Find("ScoreText").GetComponent<Text>().text = "" + score + "/20";

        string name = highscoreEntry.name;
        entryTransform.Find("NameText").GetComponent<Text>().text = name;

        transformList.Add(entryTransform);
    }
    
    public static void AddHighscoreEntry(int score, string name)
    {
        //Create Highscore Entry
        HighscoreEntry highscoreEntry = new HighscoreEntry { score = score, name = name };

        //Load saved Highscores
        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = new Highscores();

        //If the list is empty, instantiate it
        if(jsonString == "")
        {
            Debug.Log("Creating list");
            highscores.highscoreEntryList = new List<HighscoreEntry>();
        }
        //Add the existing entries
        else
        {
            Debug.Log("Loading list");
            highscores = JsonUtility.FromJson<Highscores>(jsonString);
        }        

        //Add new entry to Highscores
        highscores.highscoreEntryList.Add(highscoreEntry);

        //Save updated Highscores
        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscoreTable", json);
        PlayerPrefs.Save();
    }

    private class Highscores
    {
        public List<HighscoreEntry> highscoreEntryList;
    }

    //Represents single high score entry
    [System.Serializable]
    private class HighscoreEntry
    {
        public int score;
        public string name;
    }

}
