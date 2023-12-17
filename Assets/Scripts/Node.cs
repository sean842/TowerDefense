using UnityEngine;
using UnityEngine.EventSystems;


public class Node : MonoBehaviour
{

    public Vector3 positionOffset;
    public Color hoverColor;
    public Color notEnoughMoneyColor;

    [HideInInspector]
    public GameObject turret;
    [HideInInspector]
    public TurretBluePrint turretBluePrint;
    [HideInInspector]
    public bool isUpgraded = false;

    private Color startColor;
    private Renderer rend;

    BuildManager buildManager;


    private void Start() {
        rend = GetComponent<Renderer>();// Get the renderer and store it.
        startColor = rend.material.color;// Get the start Color and store it.
        buildManager = BuildManager.instance;
    }

    public Vector3 GetBuildPosition() {
        return transform.position + positionOffset;
    }

    private void OnMouseDown() {
        // we use it to not press on Nodes in the game while the Turrets above them.
        if (EventSystem.current.IsPointerOverGameObject()) {
            return;
        }
        // if we cant build a new turret we want to select the node to show UI.
        if (turret != null) {
            buildManager.SelectedNode(this);
            return;
        }

        if (!buildManager.CanBuild) {
            return;
        }

        //buildManager.BuildTurretOn(this);
        BuildTurret( buildManager.GetTurretToBuild() );
    }

    public void BuildTurret(TurretBluePrint bliuePrint) {
        // check if we don't have enugh money to build a turret.
        if (PlayerStat.Money < bliuePrint.cost)
        {
            Debug.Log("not enough money");
            return;
        }

        // if we have enough money we subtract the cost from player's money.
        PlayerStat.Money -= bliuePrint.cost;

        // build the turret in the spesific node.
        GameObject _turret = (GameObject)Instantiate(bliuePrint.Prefab, GetBuildPosition(), Quaternion.identity);

        turret = _turret;

        turretBluePrint = bliuePrint;

        // build the Effect in the same node.
        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);

        Destroy(effect, 5f);

    }


    public void UpgardeTurret() {
        // check if we don't have enugh money to build a turret.
        if (PlayerStat.Money < turretBluePrint.upgradeCost)
        {
            Debug.Log("not enough money to upgrade");
            return;
        }

        // if we have enough money we subtract the cost from player's money.
        PlayerStat.Money -= turretBluePrint.upgradeCost;
        // Destroy the old turret
        Destroy(turret);

        // build the upgradedTurret in the spesific node.
        GameObject _turret = (GameObject)Instantiate(turretBluePrint.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        // build the Effect in the same node.
        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        isUpgraded = true;

        Debug.Log("turret Upgraded ");

    }

    private void OnMouseEnter() {
        if (EventSystem.current.IsPointerOverGameObject()) {
            return;
        }

        if (!buildManager.CanBuild) {
            return;
        }

        if (buildManager.HasMoney) {
            rend.material.color = hoverColor;
        } else { rend.material.color = notEnoughMoneyColor; }

    }

    private void OnMouseExit() {
        rend.material.color=startColor;
    }

}
