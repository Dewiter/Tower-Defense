using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinLevel : MonoBehaviour {
	public SceneFader sceneFader;
	public string nextlevel = "level2";
	public int unlock		= 2;
	public string scene = "scene/MainMenu";

	public void Continue ()
	{
		PlayerPrefs.SetInt("levelReached", unlock);
		sceneFader.FadeTo(nextlevel);
	}
	public void Menu ()
	{
		sceneFader.FadeTo(scene);
	}
	
}
