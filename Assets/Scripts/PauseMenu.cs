using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public GameObject pauseMenu;
    public SceneFader SceneFader;
    public string menuSceneName = "MainMenu";

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.P)) {

            Toggle();
        }
    }

    public void Toggle() { 
        // Check the state on the UI Elemnt and flip it.
        pauseMenu.SetActive(!pauseMenu.activeSelf);

        // if it active we stop the game.
        if (pauseMenu.activeSelf) {
            Time.timeScale = 0f;
        }
        else { // else we let it run.
            Time.timeScale = 1f;
        }
    
    }

    public void Retry() {
        Toggle();
        SceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }

    public void Menu() {
        Debug.Log("manu");
        Toggle();
        SceneFader.FadeTo(menuSceneName);
    }

}
