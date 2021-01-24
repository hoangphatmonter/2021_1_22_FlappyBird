using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScript : MonoBehaviour
{
    public GameManager gameManager;
    [SerializeField] public float velocity = 1;
    private Rigidbody2D rb;
    //public AudioSource jumpSound;
    //public AudioSource deathSound;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //jump
            rb.velocity = Vector2.up * velocity;
            //jumpSound.Play();
            FindObjectOfType<AudioManager>().Play("ClickSound");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //deathSound.Play();
        FindObjectOfType<AudioManager>().Play("PunchSound");
        gameManager.GameOver();
    }
}
