using UnityEngine;
using System.Collections;

public class Controls : MonoBehaviour {

	public float moveSensitivity = 10;
	public float rotateSensitivity = 300;
	public float hspeed = 30;

	private float mouseYDelta;
	private float mouseXDelta;



	// Use this for initialization to ref other objects
	void Start () {
	
	}

	//graphics and controls here
	void Update () {
		mouseYDelta = Input.GetAxis ("Mouse Y");
		mouseXDelta = Input.GetAxis ("Mouse X");

	}

	// physics calcs here
	void FixedUpdate () {


		//rotation
		this.rigidbody2D.angularVelocity = mouseXDelta * rotateSensitivity;

		//is addForce better to use?

		//left/right
		this.rigidbody2D.AddForce(Vector2.right * hspeed);

		//up/down
		this.rigidbody2D.velocity = Vector2.up * mouseYDelta * moveSensitivity;

	}
}
