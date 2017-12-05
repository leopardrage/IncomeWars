using UnityEngine;
using System.Collections;

/// <summary>
/// Generic component for every entity that is supposed to be attacked.
/// It handles collision with projectiles, health loss and death. It also sets
/// the main material color to match the player color.
/// </summary>
public class Target : MonoBehaviour 
{
	public Player owner
	{
		set 
		{
			if (targetRenderer != null) 
			{
				targetRenderer.material.color = value.color;
			}
			ownerPrivate = value;
		}
		get
		{
			return ownerPrivate;
		}
	}
	public int maxHP;
	public GameObject explosion;
	public Renderer targetRenderer;

	protected int currentHP;
	protected GameController gameController;

	private Player ownerPrivate;

	protected virtual void Awake ()
	{
		gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
		currentHP = maxHP;
	}

	protected virtual void Loss(int loss)
	{
		currentHP -= loss;
		if (currentHP <= 0)
		{
			currentHP = 0;
			if (explosion != null) 
			{
				Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
			}
			Destroy(gameObject);
		}
	}

	// Physics Callabacks
	void OnTriggerEnter(Collider other)
	{
		if (other != null && other.CompareTag("Projectile"))
		{
			Projectile projectile = other.GetComponent<Projectile>();
			Debug.Assert (projectile != null);
			if (projectile.owner.index != owner.index)
			{
				Loss (projectile.damage);
				Destroy(other.gameObject);
			}
		}
	}
}
