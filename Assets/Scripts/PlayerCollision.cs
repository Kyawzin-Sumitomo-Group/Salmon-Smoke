using UnityEngine;
using System.Collections;

public class PlayerCollision : MonoBehaviour {

	private GameObject gm;
	private GameManager gmScript;

	// Use this for initialization
	void Start () {
		gm = GameObject.FindGameObjectWithTag ("GameController");
		gmScript = gm.GetComponent<GameManager> ();
		Debug.Log (gm);
		Debug.Log (gmScript);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D (Collision2D col) {
		if (col.gameObject.tag != "Boundaries") {
			Debug.Log("Collision!!!!");
			gmScript.DestroyPiece();
			gmScript.NewPiece();
		}
	}
}
