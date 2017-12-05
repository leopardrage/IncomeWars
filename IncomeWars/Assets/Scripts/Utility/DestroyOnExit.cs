using UnityEngine;
using System.Collections;

/// <summary>
/// Utility behaviour that destroys every object that exits its trigger collider
/// </summary>
public class DestroyOnExit : MonoBehaviour 
{
	void OnTriggerExit(Collider other)
	{
		Destroy(other.gameObject);
	}
}
