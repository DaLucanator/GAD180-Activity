using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreTable : MonoBehaviour
{
    public static HighScoreTable instance;

    public int totalTopScores = 10;
    private Highscores highscores;

    private Transform entryContainer;
    private Transform entryTemplate;
    private List<Transform> highscoreEntryTransformList;

    public Button Btn_ClearScores;

    void Awake()
    {
        instance = this;

        entryContainer = transform.Find("HighScoreEntryContainer");
        entryTemplate = entryContainer.Find("HighScoreEntryTemplate");

        entryTemplate.gameObject.SetActive(false);

        Instantiate();
        SortAndAddDummy();
    }

    private void TotalListEntriesDebug()
    {
        Debug.Log("Highscore entry list has " + highscores.highscoreEntryList.Count + " entries");
        foreach(HighscoreEntry entry in highscores.highscoreEntryList)
        {
            Debug.Log(entry.name + " " + entry.score);
        }
    }

    private void Instantiate()
    {
        Debug.Log("Instantiate");
        string jsonString = PlayerPrefs.GetString("highscoreTable");
        highscores = new Highscores();

        if(jsonString == "")
        {
            highscores = new Highscores();
            highscores.highscoreEntryList = new List<HighscoreEntry>();
        }
        else
        {
            highscores = JsonUtility.FromJson<Highscores>(jsonString);
        }

        TotalListEntriesDebug();
    }

    public void SortAndAddDummy()
    {
        //Sorting
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

        //Adding
        highscoreEntryTransformList = new List<Transform>();

        //Loop through the total number of top scores we want to display
        for (int i = 0; i < totalTopScores; i++)
        {
            if (i < highscores.highscoreEntryList.Count)
            {
                //This entry exists, so just create a display medium for it
                CreateHighscoreEntryTransform(highscores.highscoreEntryList[i]);
            }
            else
            {
                //Create a new dud entry
                CreateHighscoreEntryTransform(AddHighscoreEntry(0, "AAA"));
            }
        }

        //Remove any scores that aren't in the top 10
        if(highscores.highscoreEntryList.Count > totalTopScores)
        {
            int numToRemove = highscores.highscoreEntryList.Count - totalTopScores;
            Debug.Log("Removing " + numToRemove);
            highscores.highscoreEntryList.RemoveRange(totalTopScores - 1, numToRemove);
        }

        SaveScores();
        TotalListEntriesDebug();
    }

    public void ClearScores()
    {
        for (int i = 0; i < highscoreEntryTransformList.Count; i++)
        {
            Debug.Log("Destroying " + highscoreEntryTransformList[i]);
            Destroy(highscoreEntryTransformList[i].gameObject);
        }
        //Clear the Player Prefs & highscores lists too
        highscores.highscoreEntryList = new List<HighscoreEntry>();
        PlayerPrefs.SetString("highscoreTable", "");
        PlayerPrefs.Save();

        //Re-add everything to the lists
        SortAndAddDummy();
    }

    public void SaveScores()
    {
        //Save updated Highscores
        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscoreTable", json);
        PlayerPrefs.Save();
    }

    private void CreateHighscoreEntryTransform(HighscoreEntry highscoreEntry)
    {
        float templateHeight = 30f;
        Transform entryTransform = Instantiate(entryTemplate, entryContainer);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * highscoreEntryTransformList.Count);
        entryTransform.gameObject.SetActive(true);

        int rank = highscoreEntryTransformList.Count + 1;
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
        entryTransform.Find("ScoreText").GetComponent<Text>().text = "" + score + "/17";

        string name = highscoreEntry.name;
        entryTransform.Find("NameText").GetComponent<Text>().text = name;

        highscoreEntryTransformList.Add(entryTransform);
    }
    
    /// <summary>
    /// Add a high score entry with a score and name
    /// </summary>
    /// <param name="score"></param>
    /// <param name="name"></param>
    public HighscoreEntry AddHighscoreEntry(int score, string name)
    {
        Debug.LogWarning("Adding new score: " + name + " " + score);

        //Create Highscore Entry
        HighscoreEntry highscoreEntry = new HighscoreEntry { score = score, name = name };

        //Add new entry to Highscores
        highscores.highscoreEntryList.Add(highscoreEntry);

        SaveScores();
        return highscoreEntry;
    }

    private class Highscores
    {
        public List<HighscoreEntry> highscoreEntryList;
    }

    //Represents single high score entry
    [System.Serializable]
    public class HighscoreEntry
    {
        public int score;
        public string name;
    }

}
