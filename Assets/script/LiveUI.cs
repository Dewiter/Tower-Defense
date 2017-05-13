using UnityEngine;
using UnityEngine.UI;

public class LiveUI : MonoBehaviour {

	public Text liveText;
	
	// Update is called once per frame
	void Update ()
	{
		liveText.text = PlayerStats.Lives.ToString() + " LIVES";
	}
}
