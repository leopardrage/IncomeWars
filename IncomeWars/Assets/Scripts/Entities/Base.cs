using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// The main base of a player. It represent the player and has ownership of its state. It's a subclass of Target.
/// It updates the HUD (corresponding to the player) when the base is hit or a fighter is purchased
/// It also notifies the GameController to declare Game Over if destroyed.
/// </summary>
public class Base : Target
{
	public Player editorOwner; // A separate variable is needed to be able to use properties in Target class

	public Text hpText;
	public Text incomeText;
	public Text moneyText;

	void Start () 
	{ 
		owner = editorOwner;
		UpdateHUD();
	}

	public void UpdateHUD()
	{
		if (hpText != null) {
			hpText.text = "HP\n" + currentHP;
		}
		if (owner != null) {
			if (moneyText != null) {
				moneyText.text = "Money\n" + owner.money;
			}
			if (incomeText != null) {
				incomeText.text = "Income\n" + owner.income;
			}
		}
	}

	protected override void Loss(int loss)
	{
		if (gameController != null && gameController.gameState == GameController.GameState.ACTIVE) 
		{
			base.Loss(loss);
		}
		UpdateHUD();
	}

	void OnDestroy()
	{
		if (gameController != null) 
		{
			gameController.GameOver(owner);
		}
	}
}
