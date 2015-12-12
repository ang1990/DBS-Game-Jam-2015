using UnityEngine;
using System.Collections;

public class PlayerData : MonoBehaviour {

	public uint cash = 0;
	float bearsKilled = 0;
	float moveSpeed = 0;

	public float victoryCashRequirement = 5000000f;

	UIManager ui;
	OverallMarketLogic overallMarketLogic;
	StockMarketLogic stockMarketLogic;
	OpenVentureLogic openVentureLogic;

	float gameTimeElapsed = 0.0f;

	bool isLosing = false;

	void FixedUpdate() {
		if (IsPlaying ())
			gameTimeElapsed += Time.fixedDeltaTime;
	}

	// Use this for initialization
	void Awake() {
		bearsKilled = 0;
		isLosing = false;
		ui = GameObject.Find ("GameManager").GetComponent<UIManager> ();
		overallMarketLogic = GameObject.Find ("GameManager").GetComponent<OverallMarketLogic> ();
		stockMarketLogic = GameObject.Find ("GameManager").GetComponent<StockMarketLogic> ();
		openVentureLogic = GameObject.Find ("GameManager").GetComponent<OpenVentureLogic> ();
		gameTimeElapsed = 0.0f;
	}

	public bool gameIsWon() {
		return cash >= victoryCashRequirement;
	}

	// Please refer to scene manager.
	public bool IsPlaying() {
		return false;
	}

	public void AddCash(uint _amt = 1) {
		cash += _amt;
		ui.UpdateCashText (cash);
	}

	public void LoseCash(uint _amt = 1) {
		if (cash < _amt) {
			isLosing = true;
			cash = 0;
		}
		else
			cash -= _amt;
		ui.UpdateCashText (cash);
	}

	public bool SpendCash(uint _amt = 1) {
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

	public bool gameIsLost() {
		return isLosing;
	}

    // For button presses
    public void buyStockPressed()
    {
		if ( (stockMarketLogic.currentStockPricePerUnit * stockMarketLogic.buyingUnit) <= cash) {
			cash -= stockMarketLogic.currentStockPricePerUnit * stockMarketLogic.buyingUnit;
			stockMarketLogic.updateBuyingStock ();
		}
    }

    public void sellStockPressed()
    {
		if (stockMarketLogic.currentUnit > 0.0f){
			cash += stockMarketLogic.getSellingStock ();
		}
    }
}