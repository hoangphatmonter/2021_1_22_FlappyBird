using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class HighscoreTable : MonoBehaviour
{
    private Transform entryContainer;
    private Transform entryTemplate;

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
        entryContainer = transform.Find("highscoreEntryContainer");
        entryTemplate = entryContainer.Find("highscoreEntryTemplate");

        entryTemplate.gameObject.SetActive(false);

        float templateHeight = 30f;
        for(int i = 0; i < 10; i++)
        {
            Transform entryTransform = Instantiate(entryTemplate, entryContainer);
            RectTransform rect = entryTransform.GetComponent<RectTransform>();
            // set the property in the RectTransform (compare to the pivot that has been pinned in the parent (highscoreEntryContainer) )
            rect.anchoredPosition = new Vector2(0, -templateHeight * i);
            entryTransform.gameObject.SetActive(true);

            int rank = i + 1;
            string rankString;
            switch (rank)
            {
                case 1: rankString = "1st"; break;
                case 2: rankString = "2nd"; break;
                case 3: rankString = "3rd"; break;
                default: rankString = rank + "th"; break;
            }
            entryTransform.Find("posText").GetComponent<Text>().text = rankString;

            int score = Random.Range(0, 10000);
            entryTransform.Find("scoreText").GetComponent<Text>().text = score.ToString();

            string name = "Doomsday";
            entryTransform.Find("nameText").GetComponent<Text>().text = name;
        }
    }
}
