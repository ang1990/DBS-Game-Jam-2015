using UnityEngine;
using System.Collections;

public class OpenVentureLogic : MonoBehaviour {

	uint capital = 0;
	float profitPercentage = 0;
	PlayerData playerData;
	OverallMarketLogic overallMarketLogic;

	// Use this for initialization
	void Awake () {
		playerData = GameObject.Find("GameManager").GetComponent<PlayerData> ();
		overallMarketLogic = GameObject.Find ("GameManager").GetComponent<OverallMarketLogic> ();
		InvokeRepeating ("GenerateProfit", overallMarketLogic.timerSec, overallMarketLogic.timerSec);
	}
	
	// Update is called once per frame
	uint GenerateProfit () {
		profitPercentage = Random.Range (1.01f, 1.05f);
		uint newCapital = (uint) (capital * profitPercentage);
		return newCapital - capital;
	}
}
