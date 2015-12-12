using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FadeToWhiteAnimate : MonoBehaviour {

	Image img;

	float duration = 0.2f;
	float stepBy;

	void Awake() {
		stepBy = 1.0f / duration;
		img = GetComponent<Image> ();
	}

	public void RunAction() {
		StartCoroutine(FadeIn ());
	}

	IEnumerator FadeIn() {
		while (img.color.a < 0.95f) {
			Color newColor = new Color (255, 255, 255, Mathf.Min(1, img.color.a + stepBy * Time.deltaTime));
			img.color = newColor;
			Debug.Log (img.color.a);
			yield return 0;
		}
		StartCoroutine(FadeOut ());
	}

	IEnumerator FadeOut() {
		while (img.color.a > 0) {
			Color newColor = new Color (255, 255, 255, Mathf.Max(0, img.color.a - stepBy * Time.deltaTime));
			img.color = newColor;
			yield return 0;
		}
	}
}
