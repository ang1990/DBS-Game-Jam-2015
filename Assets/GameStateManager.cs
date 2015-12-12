using UnityEngine;
using System.Collections;

public class GameStateManager : MonoBehaviour {

	public enum GameState {
		Playing,
		Victory,
		Defeat
	}

	GameState currentState;
	PlayerData pData;

	// Use this for initialization
	void Awake () {
		currentState = GameState.Playing;
		pData = GetComponent<PlayerData> ();
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
			break;
		case GameState.Defeat:
			break;
		default:
			break;
		}
	}
}
