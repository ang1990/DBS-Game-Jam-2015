using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

	public AudioClip swoosh;
	float lastAttackTime;
	float attackTime = 0.25f;
	Transform _transform;
	BoxCollider coll;

	void Awake() {
		_transform = transform;
		coll = GetComponent<BoxCollider> ();
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0))
			StartCoroutine(Attack ());

	}

	IEnumerator Attack() {
		// Play the sound.
		if (swoosh) {
			AudioSource.PlayClipAtPoint (swoosh, _transform.position);	
		}
		Debug.Log ("Attack Start: " + Time.timeSinceLevelLoad.ToString());
		coll.enabled = true;
		yield return new WaitForSeconds (attackTime);
		coll.enabled = false;
		Debug.Log ("Attack End: " + Time.timeSinceLevelLoad.ToString ());
	}
}
