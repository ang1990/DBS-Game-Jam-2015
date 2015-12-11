using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	Text stockText;
	Text cashText;

	// Use this for initialization
	void Start () {
		stockText = GameObject.Find ("StockDisplay").GetComponent<Text> ();
		cashText = GameObject.Find ("MoneyDispText").GetComponent<Text> ();
	}

	public void UpdateStockText(uint value) {
		stockText.text = "$" + value.ToString ();
	}

	public void UpdateCashText(uint value) {
		cashText.text = "$" + value.ToString ();
	}


}
