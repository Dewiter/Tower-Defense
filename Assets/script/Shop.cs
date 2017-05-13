using UnityEngine;

public class Shop : MonoBehaviour {

	BuildManager buildManager;
	public TurretBlueprint standardTurret;
	public TurretBlueprint MissileLuncher;
	public TurretBlueprint laserTurret;

	void Start ()
	{
		buildManager = BuildManager.instance;
	}

	public void SelectStandardTurret ()
	{
		buildManager.SelectTurretTobuild(standardTurret);
	}

	public void SelectMissileTurret ()
	{
		buildManager.SelectTurretTobuild(MissileLuncher);
	}

	public void SelectLaserTurret ()
	{
		buildManager.SelectTurretTobuild(laserTurret);
	}
}
