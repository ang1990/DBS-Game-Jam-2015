using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

	public AudioClip swoosh;
	float lastAttackTime;
	float attackTime = 0.15f;
	float cooldownTime = 0.3f;
	Transform _transform;
	BoxCollider coll;

	BullAnimator anim;

	void Awake() {
		_transform = transform;
		anim = _transform.parent.GetComponent<BullAnimator> ();
		coll = GetComponent<BoxCollider> ();
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			if (Time.timeSinceLevelLoad > lastAttackTime + cooldownTime) {
				lastAttackTime = Time.timeSinceLevelLoad;
				StartCoroutine (Attack ());
			}
		}
	}

	IEnumerator Attack() {
		// Play the sound.
		if (swoosh) {
			AudioSource.PlayClipAtPoint (swoosh, _transform.position);	
		}
		anim.setAttack ();
		//Debug.Log ("Attack Start: " + Time.timeSinceLevelLoad.ToString());
		coll.enabled = true;
		yield return new WaitForSeconds (attackTime);
		coll.enabled = false;
		//Debug.Log ("Attack End: " + Time.timeSinceLevelLoad.ToString ());
	}
}
