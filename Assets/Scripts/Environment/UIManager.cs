using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	Text cashText;
	Text averageCostText;
	Text currentStockPriceText;
	Text currentStockUnitText;
	Text costsText;
	Text worthText;
	Text profitLossText;

    PlayerData playerData;
	StockMarketLogic stockMarketLogic;

	// Use this for initialization
	void Start () {
		cashText = GameObject.Find ("MoneyDispText").GetComponent<Text> ();
		averageCostText = GameObject.Find ("AverageCostDisplay").GetComponent<Text> ();
		currentStockPriceText = GameObject.Find ("StockDisplay").GetComponent<Text> ();
		costsText = GameObject.Find ("CostDisplay").GetComponent<Text> ();
		worthText = GameObject.Find ("WorthDisplay").GetComponent<Text> ();
		profitLossText = GameObject.Find ("ProfitLossDisplay").GetComponent<Text> ();

		playerData = GameObject.Find ("GameManager").GetComponent<PlayerData> ();
		stockMarketLogic = GameObject.Find ("GameManager").GetComponent<StockMarketLogic> ();

        cashText.text = "$" + playerData.cash.ToString();
		averageCostText.text = "$" + stockMarketLogic.averageCost.ToString();
		currentStockPriceText.text = "$" + stockMarketLogic.currentStockPricePerUnit.ToString ();
		currentStockUnitText.text = stockMarketLogic.currentUnit.ToString ();
		costsText.text = stockMarketLogic.cost.ToString ();
		worthText.text = stockMarketLogic.worth.ToString ();
		profitLossText.text = stockMarketLogic.profitLossDifference.ToString ();
	}

	public void UpdateStockMarketText(	uint averageCostVal, 
										uint currentStockPriceVal,
										uint currentUnitVal, 
										uint costsVal, 
										uint worthVal, 
										uint profitLossVal) {
		averageCostText.text = "$" + averageCostVal.ToString();
		currentStockPriceText.text = "$" + currentStockPriceVal.ToString ();
		currentStockUnitText.text = currentUnitVal.ToString ();
		costsText.text = costsVal.ToString ();
		worthText.text = worthVal.ToString ();
		profitLossText.text = profitLossVal.ToString ();
	}

	public void UpdateCashText(uint value) {
		cashText.text = "$" + value.ToString ();
	}

}
