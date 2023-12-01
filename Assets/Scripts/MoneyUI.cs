using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MoneyUI : MonoBehaviour
{

    public TextMeshProUGUI moneyText;

    // Update is called once per frame
    void Update() {
        moneyText.text = "$" + PlayerStat.Money.ToString();
    }

}
