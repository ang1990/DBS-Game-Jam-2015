using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

	public AudioClip swoosh;
	float lastAttackTime;

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0))
			PlayerAttack ();
	}

	void PlayerAttack() {
	
	}
}
