using UnityEngine;

public class Bullet : MonoBehaviour {
	
	private Transform target;
	public float speed		= 70f;
	public int	damage 		= 25;
	public float explosionRadius;
	public GameObject impactEffect;

	public void Seek (Transform _target)
	{
		target = _target;
	}
	
	void Update ()
	{
		if (!target)
		{
			Destroy(gameObject);
			return ;
		}
		Vector3 dir = target.position - transform.position;
		float distanceThisFrame = speed * Time.deltaTime;

		if (dir.magnitude <= distanceThisFrame)
		{
			HitTarget();
			return ;
		}
		transform.Translate(dir.normalized * distanceThisFrame, Space.World);
		transform.LookAt(target);
	}

	void HitTarget ()
	{
		GameObject EffectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
		Destroy(EffectIns, 5f);
		if (explosionRadius > 0f)
			Explode ();
		else
			Damage(target);
		Destroy(gameObject);
	}

	void Explode ()
	{
		Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
		foreach (Collider collider in colliders)
			if (collider.tag == "Enemy")
				Damage(collider.transform);
	}

	void Damage (Transform enemy)
	{
		Enemy e = enemy.GetComponent<Enemy>();
		if (e)
			e.TakeDamege(damage);
	}

	void OnDrawGizmosSelected ()
	{
		Gizmos.color = Color.green;
		Gizmos.DrawSphere(transform.position, explosionRadius);
	}
}
