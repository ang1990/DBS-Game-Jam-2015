using UnityEngine;
using System.Collections;

public class MainMenuManager : MonoBehaviour {

    public GameObject MainMenuObject;
    public GameObject InstructionsObject;

	// Use this for initialization
	void Start () {
        MainMenuObject = GameObject.Find("MainMenuObject");
        MainMenuObject.SetActive(true);
        InstructionsObject = GameObject.Find("InstructionsObject");
        InstructionsObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {

        

	}

    public void PlayButton()
    {
        Application.LoadLevel("InGame");
    }

    public void InstructionButton(GameObject UIObject)
    {
        UIObject.SetActive(true);
        MainMenuObject.SetActive(false);
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
