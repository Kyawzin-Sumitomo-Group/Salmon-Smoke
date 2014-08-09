using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public GameObject Player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void NewPiece() {
		GameObject go = (GameObject)Instantiate(Resources.LoadAssetAtPath("Assets/Prefabs/PlayerDiamond.prefab", typeof(GameObject)));
		go.transform.parent = Player.transform;
	}
	public void DestroyPiece() {
		GameObject.Destroy (Player.transform.GetChild (0).gameObject);
	}
}
