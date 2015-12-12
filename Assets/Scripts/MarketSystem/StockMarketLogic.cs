using UnityEngine;
using System.Collections;

public class StockMarketLogic : MonoBehaviour {

	public uint currentStockPricePerUnit = 0;
	public uint currentUnit = 0;
	public uint averageCost = 0;
	public uint cost = 0;
	public uint worth = 0;
	public uint profitLossDifference = 0;

	public uint buyingUnit = 0;
	public uint sellingUnit = 0; 

	// Use this for initializationstockPricePerUnit
	void Awake () {
		currentStockPricePerUnit = 0;
		currentUnit = 0;
		buyingUnit = 100;
		sellingUnit = currentUnit; 
		cost = 0;
		worth = currentUnit * currentStockPricePerUnit;
		uint division = currentUnit > 0 ? currentUnit : 1;
		averageCost = cost / division;
		profitLossDifference = worth - cost;
	}
	
	// Update is called once per frame
	public void updateBuyingStock () {
		currentUnit += buyingUnit;
		sellingUnit = currentUnit;
		cost += buyingUnit * currentStockPricePerUnit;
		worth = currentUnit * currentStockPricePerUnit;
		averageCost = cost / currentUnit;
		profitLossDifference = worth - cost;
	}

	public uint getSellingStock () {
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
