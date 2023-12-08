using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour
{

    public Image img;
    public AnimationCurve curve;

    // Start is called before the first frame update
    void Start() {
        StartCoroutine(FadeIn());
    }

    public void FadeTo(string scene) {
        StartCoroutine(FadeOut(scene));
    
    
    }

    IEnumerator FadeIn() {
        float t = 1f; // time variable.

        // While time is bigger then 0:
        //we decrease the the time.
        //we decrease the alpha of the image.
        // we skip to the next frame.
        while(t > 0) {
            t -= Time.deltaTime;
            float a = curve.Evaluate(t); // gives us the frame.
            img.color = new Color(0f, 0f, 0f, a);
            yield return 0; // means skip to the next frame.

        }

    }

    IEnumerator FadeOut(string scene)
    {
        float t = 0f; // time variable.

        // While time is less then 1.5:
        //we increase the the time.
        //we increase the alpha of the image.
        // we skip to the next frame.
        while (t < 1f)
        {
            t += Time.deltaTime;
            float a = curve.Evaluate(t); // gives us the frame.
            img.color = new Color(0f, 0f, 0f, a);
            yield return 0; // means skip to the next frame.

        }

        SceneManager.LoadScene(scene);

    }



}
