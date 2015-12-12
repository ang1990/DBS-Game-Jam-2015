using UnityEngine;
using System.Collections;

public class ExplosionAnimator : MonoBehaviour {

	public Sprite[] sprites;
	float refreshTime = 0.05f;
	float lastRefreshTime;
	int currentFrame;
	SpriteRenderer sr;

	// Use this for initialization
	void Awake () {
		sr = GetComponent<SpriteRenderer> ();
		currentFrame = 0;
		lastRefreshTime = Time.timeSinceLevelLoad;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.timeSinceLevelLoad > lastRefreshTime + refreshTime) {
			Debug.Log ("Current Frame: " + currentFrame.ToString ());
			lastRefreshTime = Time.timeSinceLevelLoad;
			currentFrame++;
			if (currentFrame >= 4)
				Destroy (gameObject);
			else {
				sr.enabled = true;
				sr.sprite = sprites [currentFrame];
			}
		}
	}
}
