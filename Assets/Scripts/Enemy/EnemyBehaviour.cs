using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {

	Rigidbody _rigidBody;
	PlayerData pData;

	GameObject explosion;

	float moveSpeed = 1.5f;
	int bombDamage = 100;
	int cashGain = 50;

	// Use this for initialization
	void Start () {
		explosion = null;
		_rigidBody = GetComponent<Rigidbody>();
		pData = GameObject.Find ("GameManager").GetComponent<PlayerData> ();
	}

	void FixedUpdate() {
		transform.Translate (Time.fixedDeltaTime * moveSpeed * Vector3.left);
	}

	void OnTriggerEnter(Collider other) {
		Debug.Log (other.tag);
		if (other.CompareTag ("EnemyEndpoint")) {
			Explode ();
		} else if (other.CompareTag ("PlayerWeapon")) {
			other.enabled = false;
			ReceiveHit ();
		}
	}

	void Explode() {
		pData.LoseCash ((uint)bombDamage);
		if (explosion != null)
			Instantiate (explosion);
		Destroy (gameObject);
	}

	public void ReceiveHit() {
		pData.AddCash (50);
		Destroy (gameObject);
	}
}