using UnityEngine;
using System;
using System.Collections;
using Random = UnityEngine.Random;
using UnityEngine.UI;

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

	// Use this for initialization
	void Start () 
	{
		gameOverText.text = "";
		InvokeRepeating("SendIncome", incomeTimeInterval, incomeTimeInterval);
	}

	void SendIncome()
	{
		if (isRunning)
		{
			leftBase.owner.money += leftBase.owner.income;
			rightBase.owner.money += rightBase.owner.income;
		}
	}
	
	// Update is called once per frame
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
			if (currentBase.owner.money >= prefabFighter.price)
			{
				currentBase.BuyFighter(prefabFighter);

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
