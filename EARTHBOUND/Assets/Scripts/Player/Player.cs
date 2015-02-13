using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float acceleration = 5f;
	public float jumpAcceleration = 20;
	public float maxSpeed = 10f;

	private float gravityAcceleration = 9.8f;
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
			//test if colliding with solid layer!
			accelerationY = jumpAcceleration * gravityAcceleration;
		}

		ApplyForce(rigidbody2D.mass * accelerationX, rigidbody2D.mass * accelerationY);
		updatePlayerOnScreen();
	}

	private void ApplyForce(float forceX, float forceY) {
		rigidbody2D.AddForce(new Vector2(forceX, forceY));
	}

	private void updatePlayerOnScreen() {
		if (rigidbody2D.velocity.x != 0) {
			Debug.Log("Player is moving in x direction.");
			transform.localScale = new Vector3 (rigidbody2D.velocity.x > 0 ? 1 : -1, 1);
			animator.SetInteger (animState, AnimationState.PlayerWalkAnimation.GetHashCode ());
		} else if (rigidbody2D.velocity.y > 0) {
			Debug.Log("Player is jumping.");
			animator.SetInteger (animState, AnimationState.PlayerJumpAnimation.GetHashCode ());
		} else {
			Debug.Log("Player is standing still.");
			animator.SetInteger (animState, AnimationState.PlayerIdleAnimation.GetHashCode ());
		}
	}
}

//Should map to AnimState in animator for Player object
public enum AnimationState {
	PlayerIdleAnimation = 0,
	PlayerWalkAnimation = 1,
	PlayerJumpAnimation = 2
}
