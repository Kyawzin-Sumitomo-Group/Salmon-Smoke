using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public GameObject Player;
	private Vector3 SpawnPoint;

	// Use this for initialization
	void Start () {
		SpawnPoint = Player.transform.position;

		GenerateLevel ();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void NewPiece() {
		Player.transform.position = SpawnPoint;
		GameObject go = (GameObject)Instantiate(Resources.LoadAssetAtPath("Assets/Prefabs/Shape.prefab", typeof(GameObject)));
		go.transform.parent = Player.transform;
		go.transform.localPosition = Vector3.zero;
	}
	public void DestroyPiece() {
		GameObject.Destroy (Player.transform.GetChild (0).gameObject);
	}
	public void RespawnPlayer() {
		Player.transform.DetachChildren ();
		NewPiece ();
	}

	public void GenerateLevel() {
			
		for(int i = 0; i < 20; i++) {
			GameObject shape = (GameObject)Instantiate(Resources.LoadAssetAtPath("Assets/Prefabs/Shape.prefab", typeof(GameObject)));
			shape.transform.position = new Vector3(i*7,Random.Range (-5f,5f),0);
		}

	}

}
