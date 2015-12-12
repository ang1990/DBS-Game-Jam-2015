using UnityEngine;
using System.Collections;

public class MainMenuManager : MonoBehaviour {

    public GameObject MainMenuObject;
    public GameObject InstructionsObject;
    public GameObject CreditsObject;

	// Use this for initialization
	void Start () {
        MainMenuObject = GameObject.Find("MainMenuObject");
        MainMenuObject.SetActive(true);
        InstructionsObject = GameObject.Find("InstructionsObject");
        InstructionsObject.SetActive(false);
        CreditsObject = GameObject.Find("CreditObject");
        CreditsObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {

        

	}

    public void PlayButton(int index)
    {
        Application.LoadLevel(index);
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

    public void CreditButton(GameObject UIObject)
    {
        UIObject.SetActive(true);
        MainMenuObject.SetActive(false);
    }
    public void QuitButton()
    {
       Application.Quit();
    }
}
