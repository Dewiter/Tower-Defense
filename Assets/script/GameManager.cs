using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	public GameObject GameOverUI;
	public GameObject WinUI;
	private bool gameEnd = false;
	void Update ()
	{
		if (PlayerStats.Lives <= 0 && !gameEnd)
			EndGame();
		if (WaveSpawner.waves.Length == WaveSpawner.waveIndex)
			WinLevel();
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
