using UnityEngine;
using System.Collections;

public class sprite_rend : MonoBehaviour {
	SpriteRenderer spriteRenderer;
	public const string PlayerSpriteFilenameStart = "Sprites/rage/spr_";
	
	public string pieceName = "rage";
	Sprite[] sprites = new Sprite[12];
	
	
	// Use this for initialization
	void Start () {
		for (var i = 0; i < 12; i++) {
			sprites [i] = Resources.Load<Sprite> (PlayerSpriteFilenameStart+pieceName+i);
		}

		Debug.Log (sprites[0]);

		spriteRenderer = transform.GetComponent<SpriteRenderer> ();
		spriteRenderer.sprite = sprites[2];
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public static string FormSpritePath(string pieceName)
    {
        return PlayerSpriteFilenameStart + pieceName;
    }
}
