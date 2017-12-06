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

	public ParticleSystem smoke;
	public ParticleSystem sparks;

	void Start () 
	{ 
		owner = editorOwner;
		UpdateHUD();
		UpdateDamageFX ();
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
			UpdateDamageFX ();
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

	private void UpdateDamageFX()
	{
		float damage = 1.0f - (float)currentHP / (float)maxHP;
		targetRenderer.material.SetFloat ("_DamageAmount", damage);
		if (smoke != null) 
		{
			var emission = smoke.emission;
			emission.rateOverTime = damage * 6.0f;
		}
		if (sparks != null) 
		{
			var emission = sparks.emission;
			emission.rateOverTime = damage * 6.0f;
		}
	}
}
