using UnityEngine;
using System.Collections;

public class StockMarketLogic : MonoBehaviour {

	public int currentStockPricePerUnit = 500;
	public int currentUnit = 0;
	public int averageCost = 0;
	public int cost = 0;
	public int worth = 0;
	public int profitLossDifference = 0;
	public int buyingUnit = 100;
	public AudioClip chaChing;

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

	void FixedUpdate(){
		ui.UpdateStockMarketText (averageCost, currentStockPricePerUnit, currentUnit, cost, worth, profitLossDifference);
	}
	
	// Update is called once per frame
	public void updateBuyingStock () {
		currentUnit += buyingUnit;
		cost += buyingUnit * currentStockPricePerUnit;
		averageCost = (int) cost / currentUnit;
		worth = currentUnit * currentStockPricePerUnit;
		profitLossDifference = worth - cost;

		ui.UpdateStockMarketText (averageCost, currentStockPricePerUnit, currentUnit, cost, worth, profitLossDifference);
		AudioSource.PlayClipAtPoint (chaChing, transform.position);
	}

	public int getSellingStock () {
		int finalProfit = currentUnit * currentStockPricePerUnit;

		averageCost = 0;
		currentUnit = 0;
		cost = 0;
		worth = currentUnit * currentStockPricePerUnit;
		profitLossDifference = worth - cost;

		ui.UpdateStockMarketText (averageCost, currentStockPricePerUnit, currentUnit, cost, worth, profitLossDifference);
		AudioSource.PlayClipAtPoint (chaChing, transform.position);

		return finalProfit;
	}

}
