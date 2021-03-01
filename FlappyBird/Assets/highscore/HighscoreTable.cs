using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using System.IO; // write data to save file

public class HighscoreTable : MonoBehaviour
{
    private Transform entryContainer;
    private Transform entryTemplate;

    private static List<HighscoreEntry> highscoreEntries;
    private List<Transform> transforms;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void Awake()
    {
        Transform entryObject = transform.Find("HighscoreTableGameObject");
        entryContainer = entryObject.Find("highscoreEntryContainer");
        entryTemplate = entryContainer.Find("highscoreEntryTemplate");


        /*
         * Problem: When this scripts was in HighscoreTableGameObject, this Awake method is not started when game starts.
        //entryContainer = transform.Find("highscoreEntryContainer");
        //entryTemplate = entryContainer.Find("highscoreEntryTemplate");

        */

        entryTemplate.gameObject.SetActive(false);

        // temporary solution to enable this Awake method is set HighScoreGameObject active when game start and then deactivate it
        transform.Find("HighscoreTableGameObject").gameObject.SetActive(false);

        /*
        highscoreEntries = new List<HighscoreEntry>
        {
            new HighscoreEntry{ score = 10, name = "a"},
            new HighscoreEntry{ score = 11, name = "b"},
            new HighscoreEntry{ score = 12, name = "c"},
            new HighscoreEntry{ score = 9, name = "d"}
        };
        
        

        HighscoreEntries hs = new HighscoreEntries { highscores = highscoreEntries };
        string json = JsonUtility.ToJson(hs);

        File.WriteAllText(Application.dataPath + "/savefile.json", json);
        */

        //Load the save file
        string jsonString = File.ReadAllText(Application.dataPath + "/savefile.json");
        HighscoreEntries highscoreClass = JsonUtility.FromJson<HighscoreEntries>(jsonString);
        highscoreEntries = highscoreClass.highscores;

        //sort
        SortHighscore();

        transforms = new List<Transform>();

        // load it on to the UI
        foreach (HighscoreEntry he in highscoreEntries)
        {
            CreateHighscoreEntryTransform(he, entryContainer, transforms);
        }

    }

    /*
     * This function is use to create a new record in ranking UI
     * input:   record: a record of HighcoreEntry to be create
     *          container: record's parent object (record will in this object)
     *          transformList: list records that hava already appeared in the UI
     * */
    private void CreateHighscoreEntryTransform(HighscoreEntry record, Transform container, List<Transform> transformList)
    {
        float templateHeight = 30f;
        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform rect = entryTransform.GetComponent<RectTransform>();
        // set the property in the RectTransform (compare to the pivot that has been pinned in the parent (highscoreEntryContainer) )
        rect.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
        entryTransform.gameObject.SetActive(true);

        int rank = transformList.Count + 1;
        string rankString;
        switch (rank)
        {
            case 1: rankString = "1st"; break;
            case 2: rankString = "2nd"; break;
            case 3: rankString = "3rd"; break;
            default: rankString = rank + "th"; break;
        }
        entryTransform.Find("posText").GetComponent<Text>().text = rankString;

        int score = record.score;
        entryTransform.Find("scoreText").GetComponent<Text>().text = score.ToString();

        string name = record.name;
        entryTransform.Find("nameText").GetComponent<Text>().text = name;

        transformList.Add(entryTransform);
    }

    /*
     * This method is used to check the condition and create a new record
     * */
     public static void CheckAndAddHighscoreEntry(int score, string name)
    {
        HighscoreEntry record = new HighscoreEntry { score = score, name = name };
        highscoreEntries.Add(record);

        if (highscoreEntries.Count < 10)
        {
            SortHighscore();
        }
        else
        {
            SortHighscore();
            // pop the final item
            highscoreEntries.RemoveAt(highscoreEntries.Count - 1);
        }

        // update the save file
        HighscoreEntries hs = new HighscoreEntries { highscores = highscoreEntries };
        string json = JsonUtility.ToJson(hs);
        File.WriteAllText(Application.dataPath + "/savefile.json", json);
    }

    /*
     * Sort method for highscoreEntries
     * */
     private static void SortHighscore()
    {
        for (int i = 0; i < highscoreEntries.Count; i++)
        {
            for (int j = i + 1; j < highscoreEntries.Count; j++)
            {
                if (highscoreEntries[i].score < highscoreEntries[j].score)
                {
                    //swap
                    HighscoreEntry temp = highscoreEntries[i];
                    highscoreEntries[i] = highscoreEntries[j];
                    highscoreEntries[j] = temp;
                }
            }
        }
    }


    /*
     * This class was used to contains the HighscoreEntry list to be able to store in json file.
     * */
    private class HighscoreEntries
    {
        public List<HighscoreEntry> highscores;
    }

    /*
     * Represents a high score entry
     * */
    [System.Serializable]
    private class HighscoreEntry
    {
        public int score;
        public string name;
    }
}
