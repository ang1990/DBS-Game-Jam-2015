using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	Text stockText;
	Text cashText;
    Text stockChangeIncrementText;
    Text stockChangeDecrementText;
    public uint stockChange = 50000;
    PlayerData playerData;

	// Use this for initialization
	void Start () {
		stockText = GameObject.Find ("StockDisplay").GetComponent<Text> ();
		cashText = GameObject.Find ("MoneyDispText").GetComponent<Text> ();
        stockChangeIncrementText = GameObject.Find("AddStock").GetComponentInChildren<Text> ();
        stockChangeDecrementText = GameObject.Find("MinusStock").GetComponentInChildren<Text>();
        playerData = GameObject.Find("GameManager").GetComponent<PlayerData> ();

        cashText.text = "$" + playerData.cash.ToString();
        stockText.text = "$" + playerData.stock.ToString();
        stockChangeIncrementText.text = "+$" + stockChange.ToString();
        stockChangeDecrementText.text = "-$" + stockChange.ToString();
	}

	public void UpdateStockText(uint value) {
		stockText.text = "$" + value.ToString ();
	}

	public void UpdateCashText(uint value) {
		cashText.text = "$" + value.ToString ();
	}

}
