using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{
    public static int Money;
    public int startMoney = 400;

    public static int Lives;
    public int startLives = 20;

    public static int wavwSurvived;

    private void Start() {
        Money = startMoney;
        Lives = startLives;
        wavwSurvived = 0;
    }

}
