using UnityEngine;
using System.Collections;

public class MainMenuManager : MonoBehaviour {

    public GameObject MainMenuObject;

	// Use this for initialization
	void Start () {
        MainMenuObject = GameObject.Find("MainMenuObject");
        MainMenuObject.SetActive(true);
	}

    public void PlayButton()
    {
        Application.LoadLevel("InGame");
    }
		
    public void BackButton(GameObject UIObject)
    {
        UIObject.SetActive(false);
        MainMenuObject.SetActive(true);
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
