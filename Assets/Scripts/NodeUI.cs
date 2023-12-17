using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{

    private Node target;
    public GameObject ui;
    public TextMeshProUGUI upgradeCost;
    public Button upgradeBTN;
    public TextMeshProUGUI sellText;

    public void SetTarget(Node _target) { 
        target = _target;
        transform.position = target.GetBuildPosition();
        if (!target.isUpgraded) {
            upgradeCost.text = target.turretBluePrint.upgradeCost.ToString() + "$";
            upgradeBTN.interactable = true;
        }
        else {
            upgradeCost.text = "Done";
            upgradeBTN.interactable = false;
        }

        sellText.text = "$" + target.turretBluePrint.GetSellAmount();
        ui.SetActive(true);

    }

    public void Hide() { 
        ui.SetActive(false);
    }

    public void Upgrade() {
        target.UpgardeTurret();
        BuildManager.instance.DeselectNode();
        upgradeCost.text = "200$";
    }

    public void Sell() { 
        target.SellTurret();
        BuildManager.instance.DeselectNode();
    
    }


}
