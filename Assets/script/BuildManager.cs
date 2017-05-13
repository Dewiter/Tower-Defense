using UnityEngine;

public class BuildManager : MonoBehaviour {

	public static BuildManager instance;
	private TurretBlueprint turretToBuild;
	private  Node selectedNode;	
	public bool CanBuild { get { return turretToBuild != null; } }
	public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }
	public GameObject BuildEffect;
	public GameObject sellEffect;
	public NodeUI nodeUI;

	void Awake()
	{
		if (instance)
			return ;
		instance = this;
	}
	
	public void selectNode (Node node)
	{
		if (selectedNode == node)
		{
			DeselectNode();
			return ;
		}
		selectedNode	= node;
		turretToBuild	= null;
		nodeUI.SetTarget(node);
	}

	public void DeselectNode ()
	{
		selectedNode = null;
		nodeUI.Hide();
	}

	public void SelectTurretTobuild (TurretBlueprint turret)
	{
		turretToBuild	= turret;
		DeselectNode();
	}

	public TurretBlueprint GetTurretToBuild ()
	{
		return (turretToBuild);
	}
}
