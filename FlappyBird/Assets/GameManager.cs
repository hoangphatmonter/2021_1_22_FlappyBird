﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverCanvas;
    public GameObject stopCanvas;
    public GameObject scoreCanvas;

    private void Start()
    {
        Time.timeScale = 1;
        gameOverCanvas.SetActive(false);
        stopCanvas.SetActive(false);
    }

    public void GameOver()
    {
        // use for disable continue Button
        scoreCanvas.GetComponentInChildren<UnityEngine.UI.Button>().interactable = false;
        gameOverCanvas.SetActive(true);
        Time.timeScale = 0;
    }

    public void Replay()
    {
        SceneManager.LoadScene(1);
    }

    public void Stop()
    {
        Time.timeScale = 0;
        stopCanvas.SetActive(true);
    }

    public void Continue()
    {
        Time.timeScale = 1;
        gameOverCanvas.SetActive(false);
        stopCanvas.SetActive(false);
    }

    public void ReturnMenu()
    {
        SceneManager.LoadScene(0);
    }
}