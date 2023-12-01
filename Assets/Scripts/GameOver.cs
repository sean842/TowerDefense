using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    public TextMeshProUGUI waveText;

    void OnEnable()
    {
        waveText.text = PlayerStat.wavwSurvived.ToString();
    }

    public void Retry() { 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void menu() {
        Debug.Log("menu Por Favors.");
    }

}
