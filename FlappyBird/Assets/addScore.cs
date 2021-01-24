using UnityEngine.Audio;
using UnityEngine;

public class addScore : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //GetComponent<AudioSource>().Play();

        FindObjectOfType<AudioManager>().Play("CoinSound");
        Score.score++;
    }
}
