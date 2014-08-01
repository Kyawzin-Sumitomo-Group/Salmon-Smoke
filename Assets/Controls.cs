using UnityEngine;
using System.Collections;

public class Controls : MonoBehaviour {

	public float moveSensitivity = 10;
	public float rotateSensitivity = 300;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float mouseYDelta = Input.GetAxis ("Mouse Y");
		float mouseXDelta = Input.GetAxis ("Mouse X");

		this.rigidbody2D.velocity = Vector2.up * mouseYDelta * moveSensitivity;
		this.rigidbody2D.angularVelocity = mouseXDelta * rotateSensitivity;

	}
}
