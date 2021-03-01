using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class PlayerMenu : MonoBehaviour
{
    [SerializeField]
    private Text text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickOK()
    {
        if (text.text == null) Score.playerName = "Anonymous";
        else Score.playerName = text.text;
    }
}
