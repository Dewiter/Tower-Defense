using UnityEngine;

public class GameManager : MonoBehaviour {
	public GameObject GameOverUI;
	private WaveSpawner waves;
	public GameObject WinUI;
	private bool gameEnd = false;

	void Update ()
	{
		if (PlayerStats.Lives <= 0 && !gameEnd)
		{
			EndGame();
			return ;	
		}
		if (waves.waveIndex == waves.waves.Length)
		{
			WinLevel();
			return ;
		}
	}

	void EndGame ()
	{
		GameOverUI.SetActive(true);
		gameEnd = true;
	}

	void WinLevel()
	{
		WinUI.SetActive(true);
		gameEnd = true;
	}
}
