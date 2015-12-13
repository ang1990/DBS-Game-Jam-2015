using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	Text cashText;
	Text averageCostText;
	Text currentStockPriceText;
	Text currentStockUnitText;
	Text costsText;
	Text worthText;
	Text profitLossText;

    PlayerData playerData;
	StockMarketLogic stockMarketLogic;
	GameStateManager gameStateManager;
	GameObject pauseScreen;

	// Use this for initialization
	void Start () {
		cashText = GameObject.Find ("MoneyDispText").GetComponent<Text> ();
		averageCostText = GameObject.Find ("AverageCostDisplay").GetComponent<Text> ();
		currentStockPriceText = GameObject.Find ("StockDisplay").GetComponent<Text> ();
		currentStockUnitText = GameObject.Find ("StockAmountDisplay").GetComponent<Text> ();
		costsText = GameObject.Find ("CostDisplay").GetComponent<Text> ();
		worthText = GameObject.Find ("WorthDisplay").GetComponent<Text> ();
		profitLossText = GameObject.Find ("ProfitLossDisplay").GetComponent<Text> ();

		playerData = GameObject.Find ("GameManager").GetComponent<PlayerData> ();
		stockMarketLogic = GameObject.Find ("GameManager").GetComponent<StockMarketLogic> ();
		gameStateManager = GameObject.Find ("GameManager").GetComponent<GameStateManager> ();
		pauseScreen = GameObject.Find ("PauseScreen");
		pauseScreen.SetActive (false);

        cashText.text = "$" + playerData.cash.ToString();
		averageCostText.text = "$" + stockMarketLogic.averageCost.ToString();
		currentStockPriceText.text = "$" + stockMarketLogic.currentStockPricePerUnit.ToString ();
		currentStockUnitText.text = stockMarketLogic.currentUnit.ToString ();
		costsText.text = stockMarketLogic.cost.ToString ();
		worthText.text = stockMarketLogic.worth.ToString ();
		profitLossText.text = stockMarketLogic.profitLossDifference.ToString ();
	}

	public void UpdateStockMarketText(	int averageCostVal, 
										int currentStockPriceVal,
										int currentUnitVal, 
										int costsVal, 
										int worthVal, 
										int profitLossVal) {
		averageCostText.text = "$" + averageCostVal.ToString();
		currentStockPriceText.text = "$" + currentStockPriceVal.ToString ();
		currentStockUnitText.text = currentUnitVal.ToString ();
		costsText.text = "$" + costsVal.ToString ();
		worthText.text = "$" + worthVal.ToString ();
		profitLossText.text = "$" + profitLossVal.ToString ();

		if(profitLossVal < 0){
			profitLossText.color = new Color (255f, 0f, 0f);
		} else {
			profitLossText.color = new Color (0f, 255f, 0f);
		}
	}

	public void UpdateCashText(int value) {
		cashText.text = "$" + value.ToString ();
	}

	public void newGamePressed(){
		Time.timeScale = 1.0f;
		gameStateManager.currentState = GameStateManager.GameState.Playing;
		Application.LoadLevel ("InGame");
	}

	public void exitPressed(){
		Time.timeScale = 1.0f;
		Application.LoadLevel ("TitleScene");
	}

	public void pausePressed(){
		if(gameStateManager.currentState == GameStateManager.GameState.Playing){
			pauseScreen.SetActive (true);
			Time.timeScale = 0.0f;
		}
	}

	public void resumePressed(){
		pauseScreen.SetActive (false);
		Time.timeScale = 1.0f;
	}

}
