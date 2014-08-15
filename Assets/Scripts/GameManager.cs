using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public GameObject Player;
	private Vector3 SpawnPoint = new Vector3(-8,0,0);
	public float NextGoalDistance = 5;
	private bool GoalReached = false;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void NewPiece() {
		Player.transform.position = SpawnPoint;
		GameObject go = (GameObject)Instantiate(Resources.LoadAssetAtPath("Assets/Prefabs/PlayerDiamond.prefab", typeof(GameObject)));
		go.transform.parent = Player.transform;
		go.transform.localPosition = Vector3.zero;
	}

	public void DestroyPiece() {
		GameObject.Destroy (Player.transform.GetChild (0).gameObject);
	}

	public void RespawnPlayer() {
		Player.transform.DetachChildren ();
		NewPiece ();
		if (GoalReached) {
			RespawnGoal();
		}
	}

	public void RespawnGoal() {

		GoalReached = false;
	}
}
