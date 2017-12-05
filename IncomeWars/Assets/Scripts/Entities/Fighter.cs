using UnityEngine;
using System.Collections;

/// <summary>
/// A fighter. It's a subclass of Target. It holds the fighter's parameters, current state and
/// perform movement, fire and enemy scanning logics.
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class Fighter : Target 
{
	public string fighterName;
	public KeyCode[] key;
	public int price;
	public int incomeIncrease;
	public int bounty;
	public float range;
	public float speed;
	public float fireRechargeTime;
	public float projectileSpeed;
	public int projectileDamage;
	public GameObject shot;
	public Transform shotSpawn;

	private Rigidbody rb;
	private AudioSource fireSFX;

	private Target currentTarget;
	private float nextFire;
	private Quaternion moveRotation;

	protected override void Awake()
	{
		base.Awake();
		rb = GetComponent<Rigidbody>();
		fireSFX = GetComponent<AudioSource>();
	}

	void Start()
	{
		moveRotation = transform.rotation;
	}
	
	// Update is called once per frame
	void Update () 
	{
		// If no current target exists, checks for enemies within range
		if (currentTarget == null)
		{
			currentTarget = CheckForEnemies();
		}
		// If a target is found, shoot at it according to its rate of fire
		if (currentTarget != null)
		{
			FaceOpponent();
			if (Time.time > nextFire)
			{
				nextFire = Time.time + fireRechargeTime;
				Fire();
			}
		}
		else // Otherwise, move towards the enemy base
		{
			MoveForward();
		}
	}

	void FaceOpponent()
	{
		transform.LookAt(currentTarget.gameObject.transform.position);
		rb.velocity = Vector3.zero;
	}

	void MoveForward()
	{
		transform.rotation = moveRotation;
		rb.velocity = transform.forward * speed;
	}

	Target CheckForEnemies()
	{
		Collider[] targetColliders = Physics.OverlapSphere(transform.position, range);
		foreach (Collider targetCollider in targetColliders)
		{
			Target possibleTarget = targetCollider.GetComponent<Target>();
			if (possibleTarget != null && possibleTarget.owner.index != owner.index)
			{
				return possibleTarget;
			}
		}
		return null;
	}

	void Fire ()
	{
		if (shot != null && shotSpawn != null) 
		{
			GameObject shotInstance = Instantiate(shot, shotSpawn.position, shotSpawn.rotation) as GameObject;
			shotInstance.transform.localScale = transform.localScale;

			Projectile projectileScript = shotInstance.GetComponent<Projectile>();
			if (projectileScript != null) 
			{
				projectileScript.damage = projectileDamage;
				projectileScript.speed = projectileSpeed;
				projectileScript.owner = owner;
			}
		}

		if (fireSFX != null) 
		{
			fireSFX.Play();
		}
	}
}
