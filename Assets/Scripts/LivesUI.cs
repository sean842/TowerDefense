using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LivesUI : MonoBehaviour
{

    public TextMeshProUGUI livesText;

    // Update is called once per frame
    void Update() {
        livesText.text = PlayerStat.Lives.ToString() + " Lives";
    }
}
