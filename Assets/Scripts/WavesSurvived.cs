using System.Collections;
using TMPro;
using UnityEngine;



public class WavesSurvived : MonoBehaviour
{

    public TextMeshProUGUI waveText;

    void OnEnable()
    {
        waveText.text = PlayerStat.waveSurvived.ToString();

        StartCoroutine(AnimateText());
    }

    IEnumerator AnimateText() {

        waveText.text = "0";
        int wave = 0;

        yield return new WaitForSeconds(0.7f);

        while (wave < PlayerStat.waveSurvived) {

            wave++;
            waveText.text = wave.ToString();

            yield return new WaitForSeconds(0.05f);
        }
    
    }


}
