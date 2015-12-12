using UnityEngine;
using System.Collections;

public class BullAnimator : MonoBehaviour {

	enum BullAnimState {
		Idle, 
		Moving, 
		Striking
	}

	SpriteRenderer sr;

	BullAnimState currentState;

	public Sprite[] idleSprites;
	public Sprite[] moveSprites;
	public Sprite[] strikeSprites;

	float timeSinceLastUpdate;
	float timeBetweenUpdates = 0.1f;

	int currentFrame = 0;

	// Use this for initialization
	void Awake () {
		sr = GetComponent<SpriteRenderer> ();
		currentState = BullAnimState.Idle;
		timeSinceLastUpdate = Time.timeSinceLevelLoad;
	}

	public void setAttack() {
		currentState = BullAnimState.Striking;
		currentFrame = 0;
	}

	public void setMoving() {
		currentState = BullAnimState.Moving;
		currentFrame = 0;
	}

	public void setIdle() {
		currentState = BullAnimState.Idle;
		currentFrame = 0;
	}
	// Update is called once per frame
	void Update () {
		if (Time.timeSinceLevelLoad > timeSinceLastUpdate + timeBetweenUpdates) {
			timeSinceLastUpdate = Time.timeSinceLevelLoad;
			switch (currentState) {
			case BullAnimState.Idle:
				currentFrame %= idleSprites.Length;
				sr.sprite = idleSprites [currentFrame];
				break;
			case BullAnimState.Moving:
				currentFrame %= moveSprites.Length;
				sr.sprite = moveSprites [currentFrame];
				break;
			case BullAnimState.Striking:
				if (currentFrame >= strikeSprites.Length) {
					currentState = BullAnimState.Idle;
					break;
				}
				sr.sprite = strikeSprites [currentFrame];
				break;
			}
			currentFrame++;
		}
	}
}
