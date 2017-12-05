using UnityEngine;
using System.Collections;

/// <summary>
/// Utility behaviour to destroy the parent object after a delay since its instantiation
/// </summary>
public class DestroyByTime : MonoBehaviour {

	public float lifetime;

	// Use this for initialization
	void Start ()
	{
		Destroy(gameObject, lifetime);
	}
}
