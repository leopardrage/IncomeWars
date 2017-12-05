using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	[HideInInspector] public float speed;
	[HideInInspector] public int damage;
	[HideInInspector] public Player owner;
	
	void Start()
	{
		GetComponent<Rigidbody>().velocity = transform.forward * speed;
	}
}
