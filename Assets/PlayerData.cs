using UnityEngine;
using System.Collections;

public class PlayerData : MonoBehaviour {

	uint cash = 0;
	float bearsKilled = 0;
	float moveSpeed = 0;

	float gameTimeElapsed = 0.0f;

	bool lose = false;

	// Please refer to scene manager.
	bool IsPlaying() {
		return false;
	}

	void FixedUpdate() {
		if (IsPlaying ())
			gameTimeElapsed += Time.fixedDeltaTime;
	}

	// Use this for initialization
	void Awake() {
		cash = 1000;
		bearsKilled = 0;
		lose = false;

		gameTimeElapsed = 0.0f;
	}

	void AddCash(uint _amt = 1) {
		cash += _amt;
	}

	void LoseCash(uint _amt = 1) {
		if (cash < _amt) {
			lose = true;
			cash = 0;
		}
		else
			cash -= _amt;
	}

	bool SpendCash(uint _amt = 1) {
		if (cash < _amt)
			return false;
		cash -= _amt;
		return true;
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