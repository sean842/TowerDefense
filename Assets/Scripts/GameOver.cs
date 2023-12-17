using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    public TextMeshProUGUI waveText;
    public SceneFader SceneFader;
    public string menuSceneName = "MainMenu";


    void OnEnable()
    {
        waveText.text = PlayerStat.wavwSurvived.ToString();
    }

    public void Retry() {
        SceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }

    public void menu() {
        Debug.Log("menu Por Favors.");
        SceneFader.FadeTo(menuSceneName);

    }

}
