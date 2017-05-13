using UnityEngine;
using UnityEngine.EventSystems;
public class Node : MonoBehaviour {

	public Color hoverColor;
	public Color notEnoughMoney;
	private Color standardColor;
	private Renderer rend;

	public Vector3 offset;
	[HideInInspector]
	public GameObject turret;
	[HideInInspector]
	public TurretBlueprint turretBlueprint;
	[HideInInspector]
	public bool isUpgraded = false;

	BuildManager buildmanager;

	void Start ()
	{
		rend			= GetComponent<Renderer>();
		standardColor	= rend.material.color;
		buildmanager	= BuildManager.instance;
	}

	public Vector3 GetbuildPosition ()
	{
		return (transform.position + offset);
	}

	void OnMouseDown ()
	{
		if (EventSystem.current.IsPointerOverGameObject())
			return ;
		if (turret)
		{
			buildmanager.selectNode(this);
			return ;
		}
		if (!buildmanager.CanBuild)
			return ;
		BuildTurret(buildmanager.GetTurretToBuild());
	}

	void BuildTurret (TurretBlueprint blueprint)
	{
		if (PlayerStats.Money < blueprint.cost)
			return ;
		PlayerStats.Money	-= blueprint.cost;
		GameObject _turret	= (GameObject)Instantiate(blueprint.prefab, GetbuildPosition(), Quaternion.identity);
		turret				= _turret;
		turretBlueprint		= blueprint;
		GameObject effect = (GameObject) Instantiate(buildmanager.BuildEffect, GetbuildPosition(), Quaternion.identity);
		Destroy(effect, 5f);
	}

	public void UpgradeTurret ()
	{
		if (PlayerStats.Money < turretBlueprint.upgradedCost)
			return ;
		PlayerStats.Money	-= turretBlueprint.upgradedCost;
		Destroy(turret);
		GameObject _turret	= (GameObject)Instantiate(turretBlueprint.upgradedPrefab, GetbuildPosition(), Quaternion.identity);
		turret				= _turret;
		GameObject effect = (GameObject)Instantiate(buildmanager.BuildEffect, GetbuildPosition(), Quaternion.identity);
		Destroy(effect, 5f);
		isUpgraded = true;
	}

	public void SellTurret ()
	{
		PlayerStats.Money += turretBlueprint.GetSellAmount();
		GameObject effect = (GameObject)Instantiate(buildmanager.sellEffect, GetbuildPosition(), Quaternion.identity);
		Destroy(turret);
		turret = null;
	}

	void OnMouseEnter ()
	{
		if (EventSystem.current.IsPointerOverGameObject())
			return ;
		if (!buildmanager.CanBuild)
			return ;
		if (buildmanager.HasMoney)
			rend.material.color = hoverColor;
		else
			rend.material.color = notEnoughMoney;
	}

	void OnMouseExit ()
	{
		rend.material.color = standardColor;
	}
}
