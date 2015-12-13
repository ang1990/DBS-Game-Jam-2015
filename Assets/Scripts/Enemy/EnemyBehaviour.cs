using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {

	Rigidbody _rigidBody;
	PlayerData pData;

	public GameObject explosion;

	float moveSpeed = 1.5f;
	int bombDamage = 100;
	int cashGain = 50;

	bool isMoving = true;

	// Use this for initialization
	void Start () {
		_rigidBody = GetComponent<Rigidbody>();
		pData = GameObject.Find ("GameManager").GetComponent<PlayerData> ();
	}

	void FixedUpdate() {
		if(isMoving)
			transform.Translate (Time.fixedDeltaTime * moveSpeed * Vector3.left);
	}

	void OnTriggerEnter(Collider other) {
		//Debug.Log (other.tag);
		if (other.CompareTag ("EnemyEndpoint")) {
			Explode ();
		} else if (other.CompareTag ("PlayerWeapon")) {
			other.enabled = false;
			ReceiveHit ();
		}
	}

	public IEnumerator stun(float time) {
		isMoving = false;
		yield return new WaitForSeconds (time);
		isMoving = true;
	}
		
	void Explode() {
		pData.LoseCash ((int)bombDamage);
		Instantiate (explosion, transform.position, Quaternion.AngleAxis(35,Vector3.right));
		Destroy (gameObject);
	}

	public void ReceiveHit() {
		pData.AddCash (50);
		SkillHandler playerSkill = GameObject.Find ("Player").GetComponent<SkillHandler> ();
		playerSkill.AddCharge ();
		Instantiate (explosion, transform.position, Quaternion.AngleAxis(35,Vector3.right));
		Destroy (gameObject);
	}
}