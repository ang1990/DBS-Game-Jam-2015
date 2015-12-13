using UnityEngine;
using System.Collections;

public class OpenVentureLogic : MonoBehaviour {

	int capital = 0;
	public float lowestProfitPercentage = 1.01f;
	public float highestProfitPercentage = 1.05f;
	PlayerData playerData;
	OverallMarketLogic overallMarketLogic;

	// Use this for initialization
	void Awake () {
		playerData = GameObject.Find("GameManager").GetComponent<PlayerData> ();
		overallMarketLogic = GameObject.Find ("GameManager").GetComponent<OverallMarketLogic> ();
		InvokeRepeating ("GenerateProfit", overallMarketLogic.timerInSec, overallMarketLogic.timerInSec);
	}
	
	// Update is called once per frame
	int GenerateProfit () {
		float profitPercentage = Random.Range (1.01f, 1.05f);
		int newCapital = (int) (capital * profitPercentage);
		return newCapital - capital;
	}
}
