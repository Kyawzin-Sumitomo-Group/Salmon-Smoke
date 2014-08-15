using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour {
	public float nextGoalDistance = 8;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void RespawnGoal(GameObject shape) {
		gameObject.transform.position += Vector3.right*nextGoalDistance;
	}
	
}
