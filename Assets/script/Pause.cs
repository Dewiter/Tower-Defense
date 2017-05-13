using UnityEngine;
using UnityEngine.SceneManagement;
public class Pause : MonoBehaviour {

	public GameObject UI;
	public SceneFader sceneFader;
	public string MainMenu = "scene/MainMenu";
	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
			Toggle();	
	}

	public void Toggle()
	{
		UI.SetActive(!UI.activeSelf);
		if (UI.activeSelf)
			Time.timeScale = 0f;
		else
			Time.timeScale = 1f;
	}

	public void Retry ()
	{
		Toggle();
		sceneFader.FadeTo(SceneManager.GetActiveScene().name);
	}

	public void Menu ()
	{
		Toggle();
		sceneFader.FadeTo(MainMenu);
	}
}
