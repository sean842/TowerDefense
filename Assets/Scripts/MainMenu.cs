using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public SceneFader SceneFader;

    public string levelToLoad = "MainLevel";
    public void Play() {

        SceneFader.FadeTo(levelToLoad);
    }

    public void Quit() {
        Debug.Log("exiting...");
        Application.Quit();
    }

}
