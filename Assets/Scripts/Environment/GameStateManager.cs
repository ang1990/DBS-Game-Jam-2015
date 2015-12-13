using UnityEngine;
using System.Collections;

public class GameStateManager : MonoBehaviour {

	public enum GameState {
		Playing,
		Victory,
		Defeat
	}

	GameObject winScreen;
	GameObject loseScreen;
	public GameState currentState;
	PlayerData pData;

	// Use this for initialization
	void Awake () {
		winScreen = GameObject.Find ("WinScreen");
		loseScreen = GameObject.Find ("LoseScreen");
		currentState = GameState.Playing;
		pData = GetComponent<PlayerData> ();

		winScreen.SetActive (false);
		loseScreen.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		switch(currentState) {
		case GameState.Playing:
			if (pData.gameIsLost ()) {
				currentState = GameState.Defeat;
			} else if (pData.gameIsWon ()) {
				currentState = GameState.Victory;
			}
			break;
		case GameState.Victory:
			winScreen.SetActive (true);
			Time.timeScale = 0.0f;
			break;
		case GameState.Defeat:
			loseScreen.SetActive (true);
			Time.timeScale = 0.0f;
			break;
		default:
			break;
		}
	}
}
