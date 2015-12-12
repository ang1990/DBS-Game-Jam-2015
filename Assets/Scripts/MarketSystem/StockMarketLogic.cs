using UnityEngine;
using System.Collections;

public class StockMarketLogic : MonoBehaviour {

	uint currentStockPricePerUnit = 0;
	uint currentUnit = 0;
	uint buyingUnit = 0;
	uint sellingUnit = 0; 
	uint cost = 0;
	uint worth = 0;
	uint averageCost = 0;
	uint profitLossDifference = 0;

	// Use this for initializationstockPricePerUnit
	void Awake () {
		currentStockPricePerUnit = 0;
		currentUnit = 0;
		buyingUnit = 100;
		sellingUnit = currentUnit; 
		cost = 0;
		worth = currentUnit * currentStockPricePerUnit;
		averageCost = cost / currentUnit;
		profitLossDifference = worth - cost;
	}
	
	// Update is called once per frame
	void updateBuyingStock () {
		currentUnit += buyingUnit;
		sellingUnit = currentUnit;
		cost += buyingUnit * currentStockPricePerUnit;
		worth = currentUnit * currentStockPricePerUnit;
		averageCost = cost / currentUnit;
		profitLossDifference = worth - cost;
	}

	uint getSellingStock () {
		uint finalProfit = currentUnit * currentStockPricePerUnit;
		currentUnit = 0;
		sellingUnit = 0;
		cost = 0;
		worth = currentUnit * currentStockPricePerUnit;
		averageCost = 0;
		profitLossDifference = worth - cost;
		return finalProfit;
	}

}
