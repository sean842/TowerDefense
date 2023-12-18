using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    public SceneFader sceneFader;
    public Button[] levelButtons;

    private void Start() {
        int levelReached = PlayerPrefs.GetInt("levelReached", 1); // Default to 1 if not set
        Debug.Log(levelReached);

        for (int i = 0; i < levelButtons.Length; i++) {
            if (i + 1 <= levelReached) {
                levelButtons[i].interactable = true;
            }
            else {
                levelButtons[i].interactable = false;
            }
        }
    }

    public void Select(string LevelName) {
        sceneFader.FadeTo(LevelName);
    }
}
