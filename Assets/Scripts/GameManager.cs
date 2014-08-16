using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public GameObject Player;
	public GameObject Goal;
	private Vector3 SpawnPoint = new Vector3(-8,0,0);
	public float NextGoalDistance = 5;
	
	private float timeSinceRespawn;
	private int score = 0;


	// Use this for initialization
	void Start () {
		//GenerateLevel ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI() {

		GUIStyle style = GUI.skin.GetStyle ("label");
		style.fontSize = 30;

		GUI.Label (new Rect(Screen.width-110,10,100,50),""+score,style);
	}

	public GameObject NewPiece() {
		Player.transform.position = SpawnPoint;
		GameObject go = (GameObject)Instantiate(Resources.LoadAssetAtPath("Assets/Prefabs/Shape.prefab", typeof(GameObject)));
		go.transform.parent = Player.transform;
		go.transform.localPosition = Vector3.zero;
		return go;
	}

	public void RespawnPlayer(bool GoalReached) {

		//reload level if collide at spawn point
		float timeDiff = Time.time - timeSinceRespawn;
		timeSinceRespawn = Time.time;
		if (timeDiff < .1) {
			Application.LoadLevel(Application.loadedLevel);
		}

		Player.transform.DetachChildren ();
		GameObject newPiece = NewPiece ();

		if (GoalReached) {
			score++;
			Goal.GetComponent<Goal>().RespawnGoal(newPiece);
		}
	}

	public void GenerateLevel() {
			
		for(int i = 0; i < 20; i++) {
			GameObject shape = (GameObject)Instantiate(Resources.LoadAssetAtPath("Assets/Prefabs/Shape.prefab", typeof(GameObject)));
			shape.transform.position = new Vector3(i*7,Random.Range (-5f,5f),0);
		}

	}

}
