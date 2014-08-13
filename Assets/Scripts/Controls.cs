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

	}

	// physics calcs here
	void FixedUpdate () {

		mouseYDelta = Input.GetAxis ("Mouse Y");
		mouseXDelta = Input.GetAxis ("Mouse X");

		//rotation
		this.rigidbody2D.angularVelocity = mouseXDelta * rotateSensitivity;

		//velocity
		this.rigidbody2D.velocity = Vector2.right * hspeed+Vector2.up * mouseYDelta * moveSensitivity;

		//this.rigidbody2D.constantForce.force = Vector2.right * hspeed;

	}
}
