using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public string levelToLoad = "Scene/FirstLevel";
	public SceneFader sceneFader;
	public void Play ()
	{
		sceneFader.FadeTo(levelToLoad);
	}
	
	public void Quit ()
	{
		Application.Quit();
	}
}
