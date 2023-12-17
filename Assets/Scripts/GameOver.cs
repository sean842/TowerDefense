using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

<<<<<<< Updated upstream
    public TextMeshProUGUI waveText;
=======
    public SceneFader SceneFader;
    public string menuSceneName = "MainMenu";

>>>>>>> Stashed changes


    public void Retry() { 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void menu() {
        Debug.Log("menu Por Favors.");
    }

}
