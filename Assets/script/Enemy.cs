using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {
	[HeaderAttribute("Speed")]
	public float StartSpeed		= 10f;
	public float speed;
	[HeaderAttribute("Value")]
	public int worth			= 50;
	public  GameObject DeathEffect;
	[HeaderAttribute("Health")]
	public Image healthBar;
	public float starthealth	= 100f;
	private float health;

	void Start ()
	{
		speed	= StartSpeed;
		health	= starthealth;
	}
	public void TakeDamege(float amount)
	{
		health -= amount;
		healthBar.fillAmount = health / starthealth;
		if (health <= 0)
			Die ();
	}

	public void Slow(float amount)
	{
		speed = StartSpeed * (1f - amount);
	}
	void Die ()
	{
		PlayerStats.Money += worth;
		GameObject effect = (GameObject)Instantiate(DeathEffect, transform.position, Quaternion.identity);
		Destroy(effect, 5f);
		WaveSpawner.EnemiesAlive--;
		Destroy(gameObject);
	}
}
