using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishGame : MonoBehaviour
{

    public SceneFader SceneFader;
    public string menuSceneName = "MainMenu";

    public void menu()
    {
        Debug.Log("Game Finished Menu Por Favors.");
        SceneFader.FadeTo(menuSceneName);
    }


}
