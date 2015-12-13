using UnityEngine;
using System.Collections;

public class PlayerBehaviour : MonoBehaviour {

	CharacterController charController;
	float speed = 2.0f;
	BullAnimator anim;

	public AudioClip footstep;

	float timeBetweenFootsteps = 0.15f;
	float timeMovedSinceLastFootstep;

	void Awake() {
		charController = GetComponent<CharacterController> ();
		anim = GetComponent<BullAnimator> ();
		timeMovedSinceLastFootstep = 0;
	}

	void Update() {
		if (Input.GetAxis ("Horizontal") != 0 || Input.GetAxis ("Vertical") != 0) {
			timeMovedSinceLastFootstep += Time.deltaTime;
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
		if (timeMovedSinceLastFootstep > timeBetweenFootsteps) {
			AudioSource.PlayClipAtPoint (footstep, transform.position);
			timeMovedSinceLastFootstep = 0;
		}

	}

}
