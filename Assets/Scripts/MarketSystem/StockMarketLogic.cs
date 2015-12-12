using UnityEngine;
using System.Collections;

public class StockMarketLogic : MonoBehaviour {

	public uint currentStockPricePerUnit = 500;
	public uint currentUnit = 0;
	public uint averageCost = 0;
	public uint cost = 0;
	public uint worth = 0;
	public uint profitLossDifference = 0;

	public uint buyingUnit = 100;

	UIManager ui;

	// Use this for initializationstockPricePerUnit
	void Awake () {
		currentUnit = 0;
		buyingUnit = 100; 
		cost = 0;
		worth = 0;
		averageCost = 0;
		profitLossDifference = 0;
		ui = GameObject.Find ("GameManager").GetComponent<UIManager> ();
	}
	
	// Update is called once per frame
	public void updateBuyingStock () {
		currentUnit += buyingUnit;
		cost += buyingUnit * currentStockPricePerUnit;
		averageCost = cost / currentUnit;
		worth = currentUnit * currentStockPricePerUnit;
		profitLossDifference = worth - cost;
		ui.UpdateStockMarketText (averageCost, currentStockPricePerUnit, currentUnit, cost, worth, profitLossDifference);
	}

	public uint getSellingStock () {
		uint finalProfit = currentUnit * currentStockPricePerUnit;

		averageCost = 0;
		currentUnit = 0;
		cost = 0;
		worth = currentUnit * currentStockPricePerUnit;
		profitLossDifference = worth - cost;
		ui.UpdateStockMarketText (averageCost, currentStockPricePerUnit, currentUnit, cost, worth, profitLossDifference);
		return finalProfit;
	}

}
