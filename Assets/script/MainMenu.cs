using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
	public SceneFader sceneFader;
	public void Play ()
	{
		sceneFader.FadeTo("Scene/LevelSelect");
	}
	
	public void Quit ()
	{
		Application.Quit();
	}
}
