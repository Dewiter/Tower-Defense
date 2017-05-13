using UnityEngine;

public class Turret : MonoBehaviour {

	private Transform target;
	private Enemy targetEnemy;

	[Header("Turret Structure")]
	public float range		= 15f;
	public float turnSpeed	= 10f;
	public string enemyTag	= "Enemy";
	public Transform partToRotate;
	public Transform firepoint;


	[Header("Shooting")]
	public  float fireRate			= 1f;
	private float fireCountDown		= 0f;
	public GameObject bulletPrefab;

	[Header("Laser")]
	public bool useLaser		= false;
	public int DamageOverTime	= 10;
	public float slow			= .5f;
	public LineRenderer lineRenderer;
	public ParticleSystem Impact;
	public Light ImpactLight;
	
	void Start ()
	{
		InvokeRepeating ("UpdateTarget", 0f, 0.5f);	
	}


	void UpdateTarget ()
	{
		GameObject[] enemies	= GameObject.FindGameObjectsWithTag(enemyTag);
		float  shortestDistance	= Mathf.Infinity;
		GameObject nearestEnemy	= null;
		foreach (GameObject enemy in enemies)
		{
			float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
			if (distanceToEnemy < shortestDistance)
			{
				shortestDistance	= distanceToEnemy;
				nearestEnemy		= enemy;
			}
		}
		if (nearestEnemy && shortestDistance <= range)
		{
			target		= nearestEnemy.transform;
			targetEnemy = nearestEnemy.GetComponent<Enemy>();
		}
		else
			target = null;
	}

	void Update ()
	{
		if (!target)
		{
			if (useLaser)
				if(lineRenderer.enabled)
				{
					lineRenderer.enabled	= false;
					ImpactLight.enabled		= false;
					Impact.Stop();
				}
			return ;
		}
		LockOnTarget ();
		if (useLaser)
			Laser();
		if (fireCountDown <= 0f)
		{
			if (!useLaser)
				Shoot();
			fireCountDown = 1f / fireRate;
		}
		fireCountDown -= Time.deltaTime;
	}

	void LockOnTarget ()
	{
		Vector3 dir				= target.position - transform.position;
		Quaternion lookRotation	= Quaternion.LookRotation(dir);
		Vector3 rotation		= Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
		partToRotate.rotation	= Quaternion.Euler(0f, rotation.y, 0f);
	}

	void Laser ()
	{
		targetEnemy.TakeDamege(DamageOverTime * Time.deltaTime);
		targetEnemy.Slow(slow);	
		if (!lineRenderer.enabled)
		{
			lineRenderer.enabled = true;
			ImpactLight.enabled = true;
			Impact.Play();
		}
		lineRenderer.SetPosition(0, firepoint.position);
		lineRenderer.SetPosition(1, target.position);
		Vector3 dir					= firepoint.position - target.position;
		Impact.transform.position	= target.position + dir.normalized;
		Impact.transform.rotation	= Quaternion.LookRotation(dir);
	}

	void Shoot ()
	{
		GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
		Bullet bullet = bulletGO.GetComponent<Bullet>();
		bullet.Seek(target);
	}

	void OnDrawGizmosSelected ()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, range);
	}
}