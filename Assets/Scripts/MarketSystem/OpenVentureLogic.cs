using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OpenVentureLogic : MonoBehaviour {

	public int openCapital = 0;
	public GameObject building;
	int currentCapital = 0;
	public float lowestProfitPercentage = 1.01f;
	public float highestProfitPercentage = 1.05f;
	PlayerData playerData;
	OverallMarketLogic overallMarketLogic;
	BuildingBehaviour buildingBehaviour;

	// Use this for initialization
	void Awake () {
		playerData = GameObject.Find("GameManager").GetComponent<PlayerData> ();
		overallMarketLogic = GameObject.Find ("GameManager").GetComponent<OverallMarketLogic> ();
		buildingBehaviour = building.GetComponent<BuildingBehaviour>();
		openCapital = buildingBehaviour.ventureCapital;
		currentCapital = openCapital;
		InvokeRepeating ("GenerateProfit", 0.0f, overallMarketLogic.timerInSec);
		this.gameObject.GetComponent<TextMesh> ().text = "$" + currentCapital.ToString();
	}

	void Update(){
		if(buildingBehaviour.isActive){
			this.gameObject.GetComponent<TextMesh> ().color = new Color (0f, 255f, 0f);
		}
	}

	// Update is called once per frame
	void GenerateProfit () {
		if(buildingBehaviour.isActive){
			float profitPercentage = Random.Range (lowestProfitPercentage, highestProfitPercentage);
			int newCapital = (int) ((double) (currentCapital * profitPercentage));
			int profit = newCapital - currentCapital;
			currentCapital = newCapital;
			this.gameObject.GetComponent<TextMesh> ().text = "$" + currentCapital.ToString();
			playerData.AddCash (profit);
		}
	}
}
