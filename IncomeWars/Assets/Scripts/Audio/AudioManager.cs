using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour 
{
	public static AudioManager instance = null;  

	void Awake()
	{
		Singleton ();
	}

	private void Singleton()
	{
		//Check if instance already exists
		if (instance == null) 
		{
			//if not, set instance to this
			instance = this;

			//Sets this to not be destroyed when reloading scene
			DontDestroyOnLoad(gameObject);
		}
		//If instance already exists and it's not this:
		else if (instance != this) 
		{
			//Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
			Destroy(gameObject);    
		}
	}
}
