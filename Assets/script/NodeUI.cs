using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour {
	private Node target;
	public GameObject UI;
	[HeaderAttribute("Upgrade")]
	public Text upgradeCost;
	public Button upgradeButton;
	[HeaderAttribute("Upgrade")]
	public Text sell;
	void Start ()
	{
		UI.SetActive(false);
	}
	public void SetTarget (Node _target)
	{
		target = _target;
		transform.position = target.GetbuildPosition();
		UI.SetActive(true);
		if (!target.isUpgraded)
		{
			upgradeCost.text = target.turretBlueprint.upgradedCost + "$";
			upgradeButton.interactable = true;
		}
		if (target.isUpgraded)
		{
			upgradeCost.text = "MAX";
			upgradeButton.interactable = false;
		}
		sell.text = target.turretBlueprint.GetSellAmount() + "$";
	}

	public void Hide ()
	{
		UI.SetActive(false);
	}

	public void Upgrade ()
	{
		target.UpgradeTurret();
		BuildManager.instance.DeselectNode();
	}

	public void Sell ()
	{
		target.SellTurret();
		BuildManager.instance.DeselectNode();
	}
}
