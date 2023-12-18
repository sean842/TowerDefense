using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool GameIsOver = false;
    public GameObject GameOverUI;

    public string nextLevel = "Level02";
    public int levelToUnlock = 2;

    public SceneFader SceneFader;

    private void Start() {
        GameIsOver = false;
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
        Debug.Log("Game Over");
        GameOverUI.SetActive(true);
    }

    public void WinLevel() {
        Debug.Log("gsme won");
        PlayerPrefs.SetInt("levelReached", levelToUnlock);
        SceneFader.FadeTo(nextLevel);
    }

}
