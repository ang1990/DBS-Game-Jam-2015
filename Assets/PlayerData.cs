using UnityEngine;
using System.Collections;

public class PlayerData : MonoBehaviour {

	int cash = 0;
	float bearsKilled = 0;
	float moveSpeed = 0;

	int active1Level = 0;
	int active2Level = 0;
	int active3Level = 0;

	int jobLevel = 0;
	int businessLevel = 0;
	int stocksLevel = 0;

	float gameTimeElapsed = 0.0f;

	bool lose = false;

	// Use this for initialization
	void Awake() {
		cash = 1000;
		bearsKilled = 0;
		lose = false;

		active1Level = 0;
		active2Level = 0;
		active3Level = 0;

		jobLevel = 0;
		businessLevel = 0;
		stocksLevel = 0;

		gameTimeElapsed = 0.0f;
	}

	void AddCash(uint _amt = 1) {
		cash += (int)_amt;
	}

	void RemoveCash(uint _amt = 1) {
		cash -= (int)_amt;
		if (cash < 0)
			lose = true;
	}

	void KillBear() {
		bearsKilled += 1;
	}

	float getMoveSpeed() {
		return moveSpeed;
	}

	bool gameIsLost() {
		return lose;
	}
}
