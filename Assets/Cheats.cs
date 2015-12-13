using UnityEngine;
using System.Collections;

public class Cheats : MonoBehaviour {

	PlayerData pData;
	OverallMarketLogic marketLogic;
	SkillHandler sHandler;

	void Awake() {
		pData = GetComponent<PlayerData> ();
		marketLogic = GetComponent<OverallMarketLogic> ();
		sHandler = GameObject.Find ("Player").GetComponent<SkillHandler> ();
	}

	void Update() {
		if (Input.GetKeyDown ("p")) {
			MarketFall ();
		} else if (Input.GetKeyDown ("r")) {
			Rage ();
		} else if (Input.GetKeyDown ("q")) {
			Buy100 ();
		} else if (Input.GetKeyDown ("e")) {
			SellAll();
		}
	}

	void MarketFall() {
		marketLogic.Depression ();
	}

	void Rage() {
		sHandler.SkillActivated ();
	}

	void Buy100() {
		pData.buyStockPressed ();
	}

	void SellAll() {
		pData.sellStockPressed ();
	}





}
