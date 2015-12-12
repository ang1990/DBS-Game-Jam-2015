using UnityEngine;
using System.Collections;

public class PlayerBehaviour : MonoBehaviour {

	CharacterController charController;
	float speed = 2.0f;
	BullAnimator anim;

	void Awake() {
		charController = GetComponent<CharacterController> ();
		anim = GetComponent<BullAnimator> ();
	}

	void Update() {
		if (Input.GetAxis ("Horizontal") != 0 || Input.GetAxis ("Vertical") != 0) {
			if (Input.GetAxis ("Horizontal") != 0) {
				charController.SimpleMove (Vector3.right * Input.GetAxis ("Horizontal") * speed);
				anim.setMoving ();
			}
			if (Input.GetAxis ("Vertical") != 0) {
				charController.SimpleMove (Vector3.forward * Input.GetAxis ("Vertical") * speed);
				anim.setMoving ();
			}
		} else {
			anim.setIdle ();
		}

	}

}
