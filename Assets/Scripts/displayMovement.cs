using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class displayMovement : MonoBehaviour {
	Image spriteRenderer;

	public Sprite[] sprites;
	private float startTime;
	private float duration = 0.2f;

	int frameNum = 0;

	// Use this for initialization
	void Start () {
		spriteRenderer = transform.GetComponent<Image> ();
		startTime = Time.timeSinceLevelLoad;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.timeSinceLevelLoad > duration + startTime) {
			startTime = Time.timeSinceLevelLoad;
			frameNum++;
			frameNum %= sprites.Length;
			spriteRenderer.sprite = sprites[frameNum];
		}
	}
}
