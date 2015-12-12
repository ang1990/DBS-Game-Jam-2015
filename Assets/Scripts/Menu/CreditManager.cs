using UnityEngine;
using System.Collections;

public class CreditManager : MonoBehaviour {

    public GameObject CreditObject;

	// Use this for initialization
	void Start () {
		CreditObject = GameObject.Find("CreditObject");
		CreditObject.SetActive(true);
	}

    public void PlayButton()
    {
        Application.LoadLevel("InGame");
    }

    public void BackButton()
    {
		Application.LoadLevel("MainMenu");
    }
		
}
