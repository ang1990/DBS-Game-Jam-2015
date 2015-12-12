using UnityEngine;
using System.Collections;

public class PlayerBehaviour : MonoBehaviour {

	CharacterController charController;
	float speed = 2.0f;

	void Awake() {
		charController = GetComponent<CharacterController> ();
	}

	void Update() {
		if (Input.GetAxis ("Horizontal") != 0)
			charController.SimpleMove (Vector3.right * Input.GetAxis ("Horizontal") * speed);
		if (Input.GetAxis ("Vertical") != 0)
			charController.SimpleMove (Vector3.forward * Input.GetAxis ("Vertical") * speed);
	}

}
