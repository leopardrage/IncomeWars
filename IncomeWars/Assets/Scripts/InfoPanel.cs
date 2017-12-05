using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InfoPanel : MonoBehaviour {

	public Base ownerBase;
	public GameObject fighter;

	// Use this for initialization
	void Start () 
	{
		Fighter fighterScript = fighter.GetComponent<Fighter>();
		Player owner = ownerBase.editorOwner;

		RawImage icon = transform.Find("Icon").GetComponent<RawImage>();
		icon.color = owner.color;



		Text nameText = transform.Find("NameText").GetComponent<Text>();
		nameText.text = fighterScript.name;
		Text inputText = transform.Find("InputText").GetComponent<Text>();
		inputText.text = "Press: " + fighterScript.key[owner.index].ToString();
		Text priceText = transform.Find("PriceText").GetComponent<Text>();
		priceText.text = "Price: " + fighterScript.price;
		Text incomeText = transform.Find("IncomeText").GetComponent<Text>();
		incomeText.text = "Income: +" + fighterScript.incomeIncrease;
	}
}
