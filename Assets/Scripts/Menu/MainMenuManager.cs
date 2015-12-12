using UnityEngine;
using System.Collections;

public class MainMenuManager : MonoBehaviour {

    public GameObject MainMenuObject;
<<<<<<< HEAD
    public GameObject CreditsObject;
=======
    public GameObject InstructionsObject;
>>>>>>> d8d497d1a6cd04e2071e60102f3eb6d171cc92f6

	// Use this for initialization
	void Start () {
        MainMenuObject = GameObject.Find("MainMenuObject");
        MainMenuObject.SetActive(true);
<<<<<<< HEAD


        CreditsObject = GameObject.Find("CreditObject");
        CreditsObject.SetActive(false);
=======
        InstructionsObject = GameObject.Find("InstructionsObject");
        InstructionsObject.SetActive(false);
>>>>>>> d8d497d1a6cd04e2071e60102f3eb6d171cc92f6
	}
	
	// Update is called once per frame
	void Update () {

        //if (StoryObject.activeSelf)
        //{
        //    if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.E))
        //    {
        //        StoryObject.SetActive(false);
        //        MainMenuObject.SetActive(true);
        //    }
        //}
        //else if (MainMenuObject.activeSelf)
        //{
        //    if (Input.GetKeyDown(KeyCode.S))
        //    {
        //        Application.LoadLevel(1);
        //    }
        //    else if (Input.GetKeyDown(KeyCode.H))
        //    {
        //        InstructionsObject.SetActive(true);
        //        MainMenuObject.SetActive(false);
        //    }
        //    else if (Input.GetKeyDown(KeyCode.C))
        //    {
        //        CreditsObject.SetActive(true);
        //        MainMenuObject.SetActive(false);
        //    }
        //    else if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.Escape))
        //    {
        //        Application.Quit();
        //    }
        //}
        //else if (InstructionsObject.activeSelf || CreditsObject.activeSelf)
        //{
        //    if (Input.GetKeyDown(KeyCode.B) || Input.GetKeyDown(KeyCode.Escape))
        //    {
        //        InstructionsObject.SetActive(false);
        //        CreditsObject.SetActive(false);
        //        MainMenuObject.SetActive(true);
        //    }
        //    else if (Input.GetKeyDown(KeyCode.S))
        //    {
        //        Application.LoadLevel(1);
        //    }
        //}

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
