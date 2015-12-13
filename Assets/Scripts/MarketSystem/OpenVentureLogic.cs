using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OpenVentureLogic : MonoBehaviour {

	public int openCapital = 500000;
	public GameObject building;
	int currentCapital = 0;
	public float lowestProfitPercentage = 1.01f;
	public float highestProfitPercentage = 1.05f;
	PlayerData playerData;
	OverallMarketLogic overallMarketLogic;

	// Use this for initialization
	void Awake () {
		playerData = GameObject.Find("GameManager").GetComponent<PlayerData> ();
		overallMarketLogic = GameObject.Find ("GameManager").GetComponent<OverallMarketLogic> ();
		InvokeRepeating ("GenerateProfit", 0.0f, overallMarketLogic.timerInSec);
		currentCapital = openCapital;
		GetComponent<Text> ().text = currentCapital.ToString();
	}
	
	// Update is called once per frame
	int GenerateProfit () {
		float profitPercentage = Random.Range (lowestProfitPercentage, highestProfitPercentage);
		int newCapital = (int) ((double) (currentCapital * profitPercentage));
		int profit = newCapital - currentCapital;
		currentCapital = newCapital;
		return profit;
	}
}
