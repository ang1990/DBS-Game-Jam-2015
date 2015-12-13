using UnityEngine;
using System.Collections;

public class OverallMarketLogic : MonoBehaviour {

	public float stockPriceTimerInSec = 4.0f;
	public float capitalTimerInSec = 2.0f;
	public float stockDecrementInPercentage = 0.96f;
	public float stockIncrementInPercentage = 1.06f;

	StockMarketLogic stockMarketLogic;
	UIManager ui;

	// Use this for initialization
	void Awake () {
		InvokeRepeating ("changeStockPrice", stockPriceTimerInSec, stockPriceTimerInSec);
		stockMarketLogic = GameObject.Find ("GameManager").GetComponent<StockMarketLogic> ();
		ui = GameObject.Find ("GameManager").GetComponent<UIManager> ();
	}

	public void Depression() {
		stockMarketLogic.currentStockPricePerUnit /= 2;
		changeStockPrice ();
	}

	void changeStockPrice(){
		stockMarketLogic.currentStockPricePerUnit = (int) ((double)stockMarketLogic.currentStockPricePerUnit * Random.Range (stockDecrementInPercentage, stockIncrementInPercentage));
		if(stockMarketLogic.currentStockPricePerUnit <= 10){
			stockMarketLogic.currentStockPricePerUnit = 10;
		}
		stockMarketLogic.worth = stockMarketLogic.currentUnit * stockMarketLogic.currentStockPricePerUnit;
		stockMarketLogic.profitLossDifference = stockMarketLogic.worth - stockMarketLogic.cost;
		ui.UpdateStockMarketText (stockMarketLogic.averageCost, stockMarketLogic.currentStockPricePerUnit, stockMarketLogic.currentUnit, stockMarketLogic.cost, stockMarketLogic.worth, stockMarketLogic.profitLossDifference);
	}
}
