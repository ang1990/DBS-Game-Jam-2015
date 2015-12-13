﻿using UnityEngine;
using System.Collections;

public class OverallMarketLogic : MonoBehaviour {

	public float timerInSec = 5.0f;
	public float stockDecrementInPercentage = 0.96f;
	public float stockIncrementInPercentage = 1.06f;

	StockMarketLogic stockMarketLogic;
	UIManager ui;

	// Use this for initialization
	void Awake () {
		InvokeRepeating ("changeStockPrice", timerInSec, timerInSec);
		stockMarketLogic = GameObject.Find ("GameManager").GetComponent<StockMarketLogic> ();
		ui = GameObject.Find ("GameManager").GetComponent<UIManager> ();
	}
	
	// Update is called once per frame
	void changeStockPrice(){
		stockMarketLogic.currentStockPricePerUnit = (int) ((double)stockMarketLogic.currentStockPricePerUnit * Random.Range (stockDecrementInPercentage, stockIncrementInPercentage));
		stockMarketLogic.worth = stockMarketLogic.currentUnit * stockMarketLogic.currentStockPricePerUnit;
		stockMarketLogic.profitLossDifference = stockMarketLogic.worth - stockMarketLogic.cost;
		ui.UpdateStockMarketText (stockMarketLogic.averageCost, stockMarketLogic.currentStockPricePerUnit, stockMarketLogic.currentUnit, stockMarketLogic.cost, stockMarketLogic.worth, stockMarketLogic.profitLossDifference);
	}
}
