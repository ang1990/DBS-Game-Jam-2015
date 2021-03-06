﻿using UnityEngine;
using System.Collections;

public class PlayerData : MonoBehaviour {

	public int cash = 0;
	float bearsKilled = 0;
	float moveSpeed = 0;

	public float victoryCashRequirement = 5000000f;

	UIManager ui;
	StockMarketLogic stockMarketLogic;

	float gameTimeElapsed = 0.0f;
	float timeElapsedInteger = 0.0f;

	bool isLosing = false;

	void FixedUpdate() {
		if (IsPlaying ())
			gameTimeElapsed += Time.timeSinceLevelLoad;
		if(gameTimeElapsed - timeElapsedInteger >= 1.0f){
			timeElapsedInteger += 1.0f;
		}
	}

	// Use this for initialization
	void Awake() {
		bearsKilled = 0;
		isLosing = false;
		ui = GameObject.Find ("GameManager").GetComponent<UIManager> ();
		stockMarketLogic = GameObject.Find ("GameManager").GetComponent<StockMarketLogic> ();
		gameTimeElapsed = 0.0f;
		timeElapsedInteger = 0.0f;
	}

	public bool gameIsWon() {
		return cash >= victoryCashRequirement;
	}

	public bool gameIsLost() {
		return isLosing;
	}

	// Please refer to scene manager.
	public bool IsPlaying() {
		return false;
	}

	public void AddCash(int _amt = 1) {
		cash += _amt;
		ui.UpdateCashText (cash);
	}

	public void LoseCash(int _amt = 1) {
		if (cash <= _amt) {
			isLosing = true;
			cash = 0;
		}
		else
			cash -= _amt;
		ui.UpdateCashText (cash);
	}

	public bool SpendCash(int _amt = 1) {
		if (cash < _amt)
			return false;
		cash -= _amt;
		ui.UpdateCashText (cash);
		return true;
	}

	public void KillBear() {
		bearsKilled += 1;
	}

	public float getMoveSpeed() {
		return moveSpeed;
	}

    // For button presses
    public void buyStockPressed()
    {
		if ( (stockMarketLogic.currentStockPricePerUnit * stockMarketLogic.buyingUnit) <= cash) {
			cash -= stockMarketLogic.currentStockPricePerUnit * stockMarketLogic.buyingUnit;
			stockMarketLogic.updateBuyingStock ();
			ui.UpdateCashText (cash);
		}
    }

    public void sellStockPressed()
    {
		if (stockMarketLogic.currentUnit > 0.0f){
			cash += stockMarketLogic.getSellingStock ();
			ui.UpdateCashText (cash);
		}
    }
}