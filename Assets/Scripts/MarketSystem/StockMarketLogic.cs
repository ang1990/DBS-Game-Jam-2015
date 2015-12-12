using UnityEngine;
using System.Collections;

public class StockMarketLogic : MonoBehaviour {

	uint stockPricePerUnit = 0;
	uint currentUnit = 0;
	uint buyingUnit = 0;
	uint sellingUnit = 0; 
	uint cost = 0;
	uint worth = 0;
	uint profitLossDifference = worth - cost;

	// Use this for initialization
	void Awake () {
		stockPricePerUnit = 0;
		currentUnit = 0;
		buyingUnit = 100;
		sellingUnit = currentUnit; 
		cost = 0;
		worth = currentUnit * stockPricePerUnit;
		profitLossDifference = worth - cost;
	}
	
	// Update is called once per frame
	void updateCurrentUnit (uint unitCount) {
		currentUnit = unitCount;
		sellingUnit = currentUnit;
	}

	void updateCost (uint unitCount) {
		currentUnit = unitCount;
		sellingUnit = currentUnit;
	}
}
