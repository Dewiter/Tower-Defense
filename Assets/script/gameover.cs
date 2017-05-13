using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class gameover : MonoBehaviour {
	public Text roundsText;
	public SceneFader sceneFader;
	public string scene = "scene/MainMenu";

	void OnEnable ()
	{
		roundsText.text = PlayerStats.Rounds.ToString();
	}

	public void Retry ()
	{
		sceneFader.FadeTo(SceneManager.GetActiveScene().name);
	}

	public void Menu ()
	{
		sceneFader.FadeTo(scene);
	}

}
