using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {
	public static int Money;
	public static int Lives;
	public int startLives = 4;
	public int startMoney = 400;
	public static int Rounds;

	void Start ()
	{
		Lives 	= startLives;
		Money 	= startMoney;
		Rounds 	= 0;
	}
}
