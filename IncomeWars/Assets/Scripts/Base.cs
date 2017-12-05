using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Base : Target
{
	public Player editorOwner;

	public Text hpText;
	public Text incomeText;
	public Text moneyText;

	// Use this for initialization
	void Start () 
	{ 
		owner = editorOwner;
		UpdateHUD();
	}

	void UpdateHUD()
	{
		hpText.text = "HP\n" + currentHP;
		moneyText.text = "Money\n" + owner.money;
		incomeText.text = "Income\n" + owner.income;
	}

	public void BuyFighter(Fighter fighterPrefab)
	{
		owner.money -= fighterPrefab.price;
		owner.income += fighterPrefab.incomeIncrease;
		UpdateHUD();
	}

	protected override void Loss(int loss)
	{
		base.Loss(loss);
		UpdateHUD();
	}

	void OnDestroy()
	{
		gameController.GameOver(owner);
	}
}
