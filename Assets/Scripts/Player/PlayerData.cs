using UnityEngine;
using System.Collections;

public class PlayerData : MonoBehaviour {

	public uint cash = 0;
    public uint stock = 0;
    uint maxStockPrice = 500000;
	float bearsKilled = 0;
	float moveSpeed = 0;

	float victoryCashRequirement = 5000000;

	UIManager ui;

	float gameTimeElapsed = 0.0f;

	bool lose = false;

	void FixedUpdate() {
		if (IsPlaying ())
			gameTimeElapsed += Time.fixedDeltaTime;
	}

	// Use this for initialization
	void Awake() {
		bearsKilled = 0;
		lose = false;
		ui = GameObject.Find ("GameManager").GetComponent<UIManager> ();
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
			lose = true;
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
		return lose;
	}

    // For button presses
    public void addStockPressed()
    {
        if (stock + ui.stockChange <= maxStockPrice)
        {
            stock += ui.stockChange;
            ui.UpdateStockText(stock);
        }
    }

    public void minusStockPressed()
    {
        if (stock >= ui.stockChange)
        {
            stock -= ui.stockChange;
            ui.UpdateStockText(stock);
        }
    }
}