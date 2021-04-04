using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreTable : MonoBehaviour
{
    public int totalTopScores = 10;
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

        // Simple sort
        /*
        for (int i= 0; i < highscores.highscoreEntryList.Count; i++)
        {
            for(int j = i+1; j< highscores.highscoreEntryList.Count; j++)
            {
                if (highscores.highscoreEntryList[j].score > highscores.highscoreEntryList[i].score)
                {
                    HighscoreEntry temp = highscores.highscoreEntryList[i];
                    highscores.highscoreEntryList[i] = highscores.highscoreEntryList[j];
                    highscores.highscoreEntryList[j] = temp;
                }
            }
        }
        
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
        */
        
    }

public void SortAndAddDummy()
    {
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
    }

    public void ClearScores()
    {
        for (int i = 0; i < highscoreEntryTransformList.Count; i++)
        {
            Destroy(highscoreEntryTransformList[i].gameObject);
        }

        SortAndAddDummy();

        SaveScores();

        /*
        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = new Highscores();

        for (int i = 0; i < totalTopScores; i++)
        {
            HighscoreEntry entry = highscores.highscoreEntryList[i];
            entry.score = 0;
            entry.name = "AAA";
        }
        
        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscoreTable", json);
        PlayerPrefs.Save();
        */

    }

    public void SaveScores()
    {
        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = new Highscores();

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
