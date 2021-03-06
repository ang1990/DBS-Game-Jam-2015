﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SkillHandler : MonoBehaviour {

	Image img;
	public Sprite[] sprites;
	public Sprite[] chargedSprites;

	bool fullyCharged;
	int chargeLevel;

	int currentChargedSpriteNum = 0;
	float updateSpriteTime = 0.2f;
	float lastUpdateTime;

	int numberOfCharges = 10;

	// Use this for initialization
	void Awake () {
		img = GameObject.Find ("SkillButton").GetComponent<Image> ();
		/*
		sprites = new Sprite[12];
		for (int i = 0; i < 12; i++) {
			sprites [i] = Resources.Load<Sprite> ("Resources/Sprites/rage/spr_rage" + i.ToString () + ".PNG");
			Debug.Log ("Resources/Sprites/rage/spr_rage" + i.ToString () + ".PNG");
		}
		currentChargedSpriteNum = 0;
		chargedSprites = new Sprite[2];
		chargedSprites [0] = sprites [10];
		chargedSprites [1] = sprites [11];
		*/
		chargeLevel = 0;
		fullyCharged = false;
	}

	public void AddCharge() {
		if (chargeLevel == numberOfCharges)
			return;
		chargeLevel++;
		if (chargeLevel == numberOfCharges) {
			fullyCharged = true;
		}
		img.sprite = sprites [chargeLevel];
	}

	void ResetCharges() {
		fullyCharged = false;
		chargeLevel = 0;
		img.sprite = sprites [0];
	}

	void Update() {
		if (fullyCharged) {
			if (Time.timeSinceLevelLoad > lastUpdateTime + updateSpriteTime) {
				lastUpdateTime = Time.timeSinceLevelLoad;
				currentChargedSpriteNum = (currentChargedSpriteNum + 1) % 2;
				img.sprite = chargedSprites [currentChargedSpriteNum];
			}
		}

		if(Input.GetKeyDown(KeyCode.R)){
			SkillActivated();
		}
	}

	public void SkillActivated() {
		if (!fullyCharged)
			return;
		// Fade to white animation.
		GameObject.Find ("FadingPanel").GetComponent<FadeToWhiteAnimate> ().RunAction ();
		StartCoroutine (HandleBears ());

	}

	IEnumerator HandleBears() {
		ResetCharges ();
		GameObject[] bears = GameObject.FindGameObjectsWithTag ("Enemy");
		foreach(GameObject bear in bears) {
			EnemyBehaviour scr = bear.GetComponent<EnemyBehaviour> ();
			scr.stun (updateSpriteTime);
		}
		yield return new WaitForSeconds (updateSpriteTime);
		bears = GameObject.FindGameObjectsWithTag ("Enemy");
		foreach (GameObject bear in bears) {
			EnemyBehaviour scr = bear.GetComponent<EnemyBehaviour> ();
			scr.ReceiveHit ();
		}
		ResetCharges ();
	}
}
