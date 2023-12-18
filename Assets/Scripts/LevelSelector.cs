using UnityEngine;

public class LevelSelector : MonoBehaviour
{

    public SceneFader sceneFader;

    public void Select(string LevelName) { 
        sceneFader.FadeTo(LevelName);
    }



}
