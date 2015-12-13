using UnityEngine;
using System.Collections;

public class ExplosionAnimator : MonoBehaviour {

	public Sprite[] sprites;
	float refreshTime = 0.05f;
	float lastRefreshTime;
	int currentFrame;
	SpriteRenderer sr;

	public AudioClip bombSound;

	// Use this for initialization
	void Awake () {
		sr = GetComponent<SpriteRenderer> ();
		currentFrame = 0;
		lastRefreshTime = Time.timeSinceLevelLoad;
		AudioSource.PlayClipAtPoint (bombSound, transform.position);
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.timeSinceLevelLoad > lastRefreshTime + refreshTime) {
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
