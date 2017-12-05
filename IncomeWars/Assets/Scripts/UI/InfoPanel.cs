using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// This behaviour fills an HUD icon with data for the given fighter and owner
/// </summary>
public class InfoPanel : MonoBehaviour 
{
	public Base ownerBase;
	public GameObject fighter;

	void Start () 
	{
		Fighter fighterScript = fighter.GetComponent<Fighter>();
		Player owner = ownerBase.editorOwner;

		if (fighterScript != null && owner != null) 
		{
			RawImage icon = transform.Find("Icon").GetComponent<RawImage>();
			if (icon != null) {
				icon.color = owner.color;
			}
			Text nameText = transform.Find("NameText").GetComponent<Text>();
			if (nameText != null) {
				nameText.text = fighterScript.name;
			}
			Text inputText = transform.Find ("InputText").GetComponent<Text> ();
			if (inputText != null) {
				inputText.text = "Press: " + fighterScript.key [owner.index].ToString ();
			}
			Text priceText = transform.Find ("PriceText").GetComponent<Text> ();
			if (priceText != null) {
				priceText.text = "Price: " + fighterScript.price;
			}
			Text incomeText = transform.Find ("IncomeText").GetComponent<Text> ();
			if (incomeText != null) {
				incomeText.text = "Income: +" + fighterScript.incomeIncrease;
			}
		}
	}
}
