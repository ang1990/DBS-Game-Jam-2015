﻿using UnityEngine;
using System.Collections;

public class MainMenuManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}

    public void PlayButton()
    {
        Application.LoadLevel("Tutorial");
    }

    public void CreditButton()
    {
		Application.LoadLevel ("Credits");
    }

    public void QuitButton()
    {
       Application.Quit();
    }
}
