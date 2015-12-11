using UnityEngine;
using System.Collections;

public class PlayerData : MonoBehaviour {

	uint cash = 0;
	float bearsKilled = 0;
	float moveSpeed = 0;

	float gameTimeElapsed = 0.0f;

	bool lose = false;

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

	// Please refer to scene manager.
	public bool IsPlaying() {
		return false;
	}

	public void AddCash(uint _amt = 1) {
		cash += _amt;
	}

	public void LoseCash(uint _amt = 1) {
		if (cash < _amt) {
			lose = true;
			cash = 0;
		}
		else
			cash -= _amt;
	}

	public bool SpendCash(uint _amt = 1) {
		if (cash < _amt)
			return false;
		cash -= _amt;
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
}