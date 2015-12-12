using UnityEngine;
using System.Collections;

public class BearAnimator : MonoBehaviour {

	public Sprite[] sprites;
	SpriteRenderer sr;

	float timeSinceLastUpdate;
	float timeBetweenUpdates = 0.05f;

	int frameNum = 0;

	// Use this for initialization
	void Start () {
		sr = GetComponent<SpriteRenderer> ();
		timeSinceLastUpdate = Time.timeSinceLevelLoad;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.timeSinceLevelLoad > timeBetweenUpdates + timeSinceLastUpdate) {
			timeSinceLastUpdate = Time.timeSinceLevelLoad;
			frameNum++;
			frameNum %= sprites.Length;
			sr.sprite = sprites [frameNum];
		}
	}
}
