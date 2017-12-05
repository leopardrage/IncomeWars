using UnityEngine;
using System;
using System.Collections;
using Random = UnityEngine.Random;
using UnityEngine.UI;

/// <summary>
/// This controller handles player input, high level game logic (income) and game over feedback
/// </summary>
public class GameController : MonoBehaviour 
{
	public float incomeTimeInterval;

	public Base leftBase;
	public Base rightBase;

	public GameObject smallest;
	public GameObject small;
	public GameObject medium;
	public GameObject large;
	public GameObject largest;

	public float minDeployRange;
	public float maxDeployRange;

	[HideInInspector]
	public bool isRunning = true;

	public Text gameOverText;

	void Start () 
	{
		if (gameOverText != null) 
		{
			gameOverText.text = "";
		}
		InvokeRepeating("SendIncome", incomeTimeInterval, incomeTimeInterval);
	}

	void SendIncome()
	{
		if (isRunning)
		{
			if (leftBase != null) 
			{
				leftBase.owner.money += leftBase.owner.income;
				leftBase.UpdateHUD ();
			}
			if (rightBase != null) 
			{
				rightBase.owner.money += rightBase.owner.income;
				rightBase.UpdateHUD ();
			}
		}
	}

	void Update ()
	{
		Base currentBase = null;
		GameObject toBeInstatiated = null;

		if(Input.GetKeyDown(KeyCode.Q))
		{
			toBeInstatiated = smallest;
			currentBase = leftBase;
		}
		else if(Input.GetKeyDown(KeyCode.W))
		{
			toBeInstatiated = small;
			currentBase = leftBase;
		}
		else if(Input.GetKeyDown(KeyCode.E))
		{
			toBeInstatiated = medium;
			currentBase = leftBase;
		}
		else if(Input.GetKeyDown(KeyCode.R))
		{
			toBeInstatiated = large;
			currentBase = leftBase;
		}
		else if(Input.GetKeyDown(KeyCode.T))
		{
			toBeInstatiated = largest;
			currentBase = leftBase;
		}
		else if(Input.GetKeyDown(KeyCode.Y))
		{
			toBeInstatiated = smallest;
			currentBase = rightBase;
		}
		else if(Input.GetKeyDown(KeyCode.U))
		{
			toBeInstatiated = small;
			currentBase = rightBase;
		}
		else if(Input.GetKeyDown(KeyCode.I))
		{
			toBeInstatiated = medium;
			currentBase = rightBase;
		}
		else if(Input.GetKeyDown(KeyCode.O))
		{
			toBeInstatiated = large;
			currentBase = rightBase;
		}
		else if(Input.GetKeyDown(KeyCode.P))
		{
			toBeInstatiated = largest;
			currentBase = rightBase;
		}

		if (toBeInstatiated != null && currentBase != null)
		{
			Fighter prefabFighter = toBeInstatiated.GetComponent<Fighter>();
			if (prefabFighter != null && currentBase.owner.money >= prefabFighter.price)
			{
				// Purchase the fighter
				currentBase.owner.money -= prefabFighter.price;
				currentBase.owner.income += prefabFighter.incomeIncrease;
				currentBase.UpdateHUD ();

				// Spawn the fighter
				Vector3 position;
				Quaternion rotation;
				if (currentBase == leftBase)
				{
					position = new Vector3(currentBase.gameObject.transform.position.x + 2.0f, 0.0f, Random.Range(minDeployRange, maxDeployRange));
					rotation = Quaternion.Euler(new Vector3(0.0f, 90.0f, 0.0f));
				}
				else
				{
					position = new Vector3(currentBase.gameObject.transform.position.x - 2.0f, 0.0f, Random.Range(minDeployRange, maxDeployRange));
					rotation = Quaternion.Euler(new Vector3(0.0f, -90.0f, 0.0f));
				}
				GameObject fighter = Instantiate(toBeInstatiated, position, rotation) as GameObject;
				Fighter fighterScript = fighter.GetComponent<Fighter>();
				Debug.Assert (fighterScript != null);
				fighterScript.owner = currentBase.owner;
			}
		}
	}

	public void GameOver (Player loser)
	{
		isRunning = false;
		if (gameOverText != null) 
		{
			gameOverText.text = loser.name + "\nhas been destroyed!";
		}
	}
}
