using UnityEngine;
using System.Collections;

public class BuildingBehaviour : MonoBehaviour {

	float timeActivated;
	float riseSpeed = 10.0f;
	Transform _transform;

	PlayerData pData;

	// Change value in inspector!
	public bool isActive = false;
	public int ventureCapital;

	// Use this for initialization
	void Awake () {
		isActive = false;
		_transform = transform;
		pData = GameObject.Find ("GameManager").GetComponent<PlayerData> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (isActive) {
			if (_transform.position.y < -0.05f) {
				_transform.position = new Vector3 (_transform.position.x, _transform.position.y * 0.75f, _transform.position.z);
				if(_transform.position.y > -0.05f)
					_transform.position = new Vector3 (_transform.position.x, 0, _transform.position.z);
			} else {
				// Work your money-making logic here!!!
			}
		}
	}

	void OnMouseUpAsButton() {
		Debug.Log ("OnMouseDown");
		if (pData.SpendCash (ventureCapital))
			isActive = true;
	}
}
