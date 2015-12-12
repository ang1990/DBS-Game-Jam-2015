using UnityEngine;
using System.Collections;

public class GameOverManager : MonoBehaviour {

	GameObject gameOverObject;

	// Use this for initialization
	void Start () {
		gameOverObject = GameObject.Find("GameOverObject");
		gameOverObject.SetActive(true);
	}

    public void BackButton()
    {
		Application.LoadLevel("MainMenu");
    }
		
}
