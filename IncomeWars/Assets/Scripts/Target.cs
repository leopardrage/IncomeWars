using UnityEngine;
using System.Collections;

public class Target : MonoBehaviour 
{
	public Player owner
	{
		set 
		{
			targetRenderer.material.color = value.color;
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

	void OnTriggerEnter(Collider other)
	{
		if (other != null && other.CompareTag("Projectile"))// && gameController.isRunning)
		{
			Projectile projectile = other.GetComponent<Projectile>();
			if (projectile.owner.index != owner.index)
			{
				Loss (projectile.damage);
				Destroy(other.gameObject);
			}
		}
	}

	protected virtual void Loss(int loss)
	{
		currentHP -= loss;
		if (currentHP <= 0)
		{
			Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
			Destroy(gameObject);
		}
	}
}
