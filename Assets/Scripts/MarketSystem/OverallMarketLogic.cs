using UnityEngine;
using System.Collections;

public class OverallMarketLogic : MonoBehaviour {

	public float timerInSec = 0.0f;

	StockMarketLogic stockMarketLogic;

	// Use this for initialization
	void Awake () {
		timerInSec = 5.0f;
		InvokeRepeating ("changeStockPrice", 0.0f, timerInSec);
		stockMarketLogic = GameObject.Find ("GameManager").GetComponent<StockMarketLogic> ();
	}
	
	// Update is called once per frame
	void changeStockPrice(){
		stockMarketLogic.currentStockPricePerUnit = (int) ((double)stockMarketLogic.currentStockPricePerUnit * Random.Range (0.96f, 1.06f));
	}
}
