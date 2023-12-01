using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    private void Awake() {
        if (instance != null) {
            Debug.LogError("more then 1 instance in the scene!");
            return;
        }
        instance = this;
    }

    private TurretBluePrint turretToBuild;
    public GameObject buildEffect;
    private Node selectedNode;
    public NodeUI nodeUI;

    /// <summary>
    /// check if we have turret to build. return True/False.
    /// </summary>
    public bool CanBuild { get { return turretToBuild != null; } }
    /// <summary>
    /// check if we have enough money to build. return True/False.
    /// </summary>
    public bool HasMoney { get { return PlayerStat.Money >= turretToBuild.cost; } }


    public void SelectedNode(Node node) { 

        if(selectedNode == node) {
            DeselectNode();
            return;
        }
        selectedNode = node;
        turretToBuild = null;
        nodeUI.SetTarget(node);
    }

    public void DeselectNode() {
        selectedNode = null;
        nodeUI.Hide();
    }


    public void SelectTurretToBuild(TurretBluePrint turret) {
        turretToBuild = turret;
        DeselectNode();
    }

    public TurretBluePrint GetTurretToBuild() { 
        return turretToBuild;
    }

}
