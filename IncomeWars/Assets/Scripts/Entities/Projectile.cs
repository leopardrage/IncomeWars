using UnityEngine;
using System.Collections;

/// <summary>
/// Generic component for every entity that is supposed to be attacked.
/// It handles collision with projectiles, health loss and death. It also sets
/// the main material color to match the player color.
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour {

	[HideInInspector] public float speed;
	[HideInInspector] public int damage;
	[HideInInspector] public Player owner;
	
	void Start()
	{
		GetComponent<Rigidbody>().velocity = transform.forward * speed;
	}
}
