using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float acceleration = 0.5f;
	public float maxSpeed = 2.5f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float accelerationX = 0f;
		float accelerationY = 0f;

		var currentVelocityX = Mathf.Abs(rigidbody2D.velocity.x);
		var currentVelocityY = Mathf.Abs(rigidbody2D.velocity.y);

		if(Input.GetKey(KeyCode.RightArrow)) {
			Debug.Log("Right key down");
			if(currentVelocityX < maxSpeed) {
				accelerationX += acceleration;
				Debug.Log("Adding acceleration: " + acceleration);
			
			}
		}

		if(Input.GetKey(KeyCode.LeftArrow)) {
			if(currentVelocityX > -maxSpeed) {
				accelerationX -= acceleration;
			}
		}

		if(Input.GetKey(KeyCode.DownArrow)) {
			// dont know what to do here
		}

		if(Input.GetKey(KeyCode.UpArrow)) {
			//jump? jump twice?
		}

		ApplyForce(rigidbody2D.mass * accelerationX, rigidbody2D.mass * accelerationY);
	}

	private void ApplyForce(float forceX, float forceY) {
		rigidbody2D.AddForce(new Vector2(forceX, forceY));
	}
}
