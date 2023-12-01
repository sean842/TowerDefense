using UnityEngine;

public class ShopScript : MonoBehaviour
{
    public TurretBluePrint standardTurret;
    public TurretBluePrint MisiileLauncher;
    public TurretBluePrint laserBeamer;

    BuildManager buildManager;

    private void Start() {
        buildManager = BuildManager.instance;
    }

    public void SelectStandardTurret() {
        Debug.Log("Standard turret selected");
        buildManager.SelectTurretToBuild(standardTurret);
    }

    public void SelectMissileLauncher() {
        Debug.Log("Missile Launcher selected");
        buildManager.SelectTurretToBuild(MisiileLauncher);
    }

    public void SelectLaserBeamer() {
        Debug.Log("Laser Beamer selected");
        buildManager.SelectTurretToBuild(laserBeamer);
    }

}
