using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool GameIsOver = false;
    public GameObject GameOverUI;
    public GameObject CompleteLevelUI;
    public GameObject finishedGameUI;

    //public int currentLevel = 1;

    public int nextSceneIndex = 0;


    //public SceneFader SceneFader;

    private void Start() {
        GameIsOver = false;
        nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameIsOver) {
            return;
        }

        if (Input.GetKeyDown("e")) { 
            EndGame();
        }

        if (PlayerStat.Lives <= 0) {
            EndGame();
        }
    }

    void EndGame() {
        GameIsOver = true;
        GameOverUI.SetActive(true);
    }

    public void WinLevel() {
        //currentLevel++;
        GameIsOver = true;
        CompleteLevelUI.SetActive(true);
    }

    public void FinishedGame() {
        Debug.Log("finishhhh");
        GameIsOver = true;
        finishedGameUI.SetActive(true);
    }

}
