using UnityEngine;
using UnityEngine.SceneManagement;

public class CompleteLevel : MonoBehaviour
{

    public SceneFader SceneFader;
    public int levelsTotal = 3;

    public string nextLevel = "Level02";
    public int levelToUnlock = 2;

    public string menuSceneName = "MainMenu";


    public void Continue()
    {

        int currentLevelNumber = SceneManager.GetActiveScene().buildIndex - 1;

        if(currentLevelNumber < levelsTotal) {
            nextLevel = "Level" + (currentLevelNumber + 1).ToString("D2");
            SceneFader.FadeTo(nextLevel);
        }
        else {
            SceneFader.FadeTo(menuSceneName);
        }

        levelToUnlock++;

        PlayerPrefs.SetInt("levelReached", levelToUnlock);
        //SceneFader.FadeTo(nextLevel);

    }

    public void Menu() { 
        SceneFader.FadeTo(menuSceneName);
    }

}
