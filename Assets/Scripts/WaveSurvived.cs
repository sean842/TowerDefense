using System.Collections;
using TMPro;
using UnityEngine;

public class WaveSurvived : MonoBehaviour
{
    public TextMeshProUGUI waveText;

    void OnEnable()
    {
        StartCoroutine(AnimateText());
    }

    IEnumerator AnimateText() {
        waveText.text = "0";
        int round = 0;

        yield return new WaitForSeconds(2f);

        while (round < PlayerStat.wavwSurvived) { 
            round++;
            waveText.text = round.ToString();
            yield return new WaitForSeconds(.05f);
        
        }
    }

}
