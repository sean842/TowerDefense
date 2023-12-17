using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteLevel : MonoBehaviour
{

    public SceneFader SceneFader;
    public string menuSceneName = "MainMenu";

    public string nextLevel = "Level02";
    public int levelToUnlock = 2;


    public void menu() {
        Debug.Log("menu Por Favors.");
        SceneFader.FadeTo(menuSceneName);
    }

    public void Continue() {
        PlayerPrefs.SetInt("levelReached", levelToUnlock);
        SceneFader.FadeTo(nextLevel);
    }



}
