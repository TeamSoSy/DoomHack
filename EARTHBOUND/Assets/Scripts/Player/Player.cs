using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float acceleration = 5f;
	public float maxSpeed = 10f;

	private Animator animator;
	private const string animState = "AnimState"; //This should probably be a constant somewhere throughout app

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		float accelerationX = 0f;
		float accelerationY = 0f;

		var currentVelocityX = Mathf.Abs(rigidbody2D.velocity.x);
		var currentVelocityY = Mathf.Abs(rigidbody2D.velocity.y);

		if(Input.GetKey(KeyCode.RightArrow)) {
			if(currentVelocityX < maxSpeed) {
				accelerationX = acceleration;
			}
		}

		if(Input.GetKey(KeyCode.LeftArrow)) {
			if(currentVelocityX > -maxSpeed) {
				accelerationX = -acceleration;
			}
		}

		if(Input.GetKey(KeyCode.DownArrow)) {
			// dont know what to do here
		}

		if(Input.GetKeyUp(KeyCode.UpArrow)) {
			//jump? jump twice?
		}

		ApplyForce(rigidbody2D.mass * accelerationX, rigidbody2D.mass * accelerationY);
	}

	private void ApplyForce(float forceX, float forceY) {
		if (forceX != 0) {
			transform.localScale = new Vector3 (forceX > 0 ? 1 : -1, 1);
			animator.SetInteger (animState, AnimationState.PlayerWalkAnimation.GetHashCode ());
		} else {
			animator.SetInteger(animState, AnimationState.PlayerIdleAnimation.GetHashCode());
		}

		rigidbody2D.AddForce(new Vector2(forceX, forceY));

		print (rigidbody2D.velocity);
	}
}

//Should map to AnimState in animator for Player object
public enum AnimationState {
	PlayerIdleAnimation = 0,
	PlayerWalkAnimation = 1
}
