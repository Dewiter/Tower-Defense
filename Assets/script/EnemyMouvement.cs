using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMouvement : MonoBehaviour {
	private int wavepointIndex	= 0;
	private Transform target;
	private Enemy enemy;


	void Start ()
	{
		enemy	= GetComponent<Enemy>();
		target	= Waypoints.points[0];
	}
	
	void Update ()
	{
		Vector3 dir = target.position - transform.position;
		transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);
		if (Vector3.Distance(transform.position, target.position) < 0.4f)
			GetNextWaypoint();
		enemy.speed = enemy.StartSpeed;
	}

	void GetNextWaypoint ()
	{
		if (wavepointIndex >= Waypoints.points.Length - 1)
		{
			EndPath();
			return ;
		}
		wavepointIndex++;
		target = Waypoints.points[wavepointIndex];
	}

	void EndPath ()
	{
		PlayerStats.Lives--;
		WaveSpawner.EnemiesAlive--;
		Destroy(gameObject);
	}
}
