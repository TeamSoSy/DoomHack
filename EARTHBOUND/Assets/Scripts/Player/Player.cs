﻿using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float acceleration = 10f;
	public float jumpForce = 100;
	public float maxSpeed = 10f;
	public GameObject endPoint;
	public float maxSecondsBeforeDying = 2;

	private const float gravityAcceleration = -9.8f;
	private Vector2 standingBoxColliderSize {
		get {
			return new Vector2 (0.66f, 0.9f);
		}
	}
	private Vector2 duckedBoxColliderSize {
		get {
			return new Vector2 (0.66f, 0.7f);
		}
	}
	
	private Animator animator;
	private const string animState = "AnimState"; //This should probably be a constant somewhere throughout app

	private PlayerState state;
	private int jumpCount = 0;

	private float timeSinceOnGroundSeconds = 0;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		switch (state) {
		case PlayerState.Moving:
			animator.SetInteger (animState, PlayerAnimState.PlayerWalkAnimation.GetHashCode());
			transform.localScale = new Vector3 (rigidbody2D.velocity.x > 0 ? 1 : -1, 1);
			break;
		case PlayerState.Ducking:
			animator.SetInteger (animState, PlayerAnimState.PlayerDuckAnimation.GetHashCode());
			break;
		case PlayerState.Jumping:
			animator.SetInteger (animState, PlayerAnimState.PlayerJumpAnimation.GetHashCode());
			break;
		case PlayerState.Standing:
			animator.SetInteger (animState, PlayerAnimState.PlayerIdleAnimation.GetHashCode());
			gameObject.GetComponent<BoxCollider2D> ().size = standingBoxColliderSize;
			break;
		}

		if (!onGround ()) {
			timeSinceOnGroundSeconds += Time.deltaTime;
		} else {
			timeSinceOnGroundSeconds = 0;
		}

		if (timeSinceOnGroundSeconds > maxSecondsBeforeDying) {
			Destroy (gameObject);
			Debug.Log("Player has died D:");
		}
	}

	private void checkForResources() {
	
	}

	private bool hasResource() {
		return true;
	}


	private bool onGround() {
		if (!endPoint) {
			return false;
		}
		return Physics2D.Linecast(transform.position, endPoint.transform.position, 1 << LayerMask.NameToLayer ("Solid"));
	}

	private void ApplyForce(float forceX, float forceY) {
		rigidbody2D.AddForce(new Vector2(forceX, forceY));
	}

	public void StandUp() {
		state = PlayerState.Standing;
	}

	public void Duck() {
		gameObject.GetComponent<BoxCollider2D> ().size = duckedBoxColliderSize;
		state = PlayerState.Ducking;
	}

	public void Jump() {
		if (onGround ()) {
			jumpCount = 0;
		} else if (hasResource()) {
			jumpCount++;
		}

		if (jumpCount < 2) {
			ApplyForce (0, (rigidbody2D.mass * -gravityAcceleration) + jumpForce);//Cancel out gravity and apply jump force
			state = PlayerState.Jumping;
		}
	}

	public void MoveRight() {
		float accelerationX = 0f;
		var currentVelocityX = Mathf.Abs(rigidbody2D.velocity.x);

		if(currentVelocityX < maxSpeed) {
			accelerationX = acceleration;
		}

		ApplyForce(rigidbody2D.mass * accelerationX, 0);
		state = PlayerState.Moving;
	}

	public void MoveLeft() {
		float accelerationX = 0f;
		var currentVelocityX = Mathf.Abs (rigidbody2D.velocity.x);
		
		if (currentVelocityX > -maxSpeed) {
			accelerationX = -acceleration;
		}
		
		ApplyForce (rigidbody2D.mass * accelerationX, 0);
		state = PlayerState.Moving;
	}
	
	public PlayerState getState() {
		return state;
	}
}

//Should map to AnimState in animator for Player object
public enum PlayerAnimState {
	PlayerIdleAnimation = 0,
	PlayerWalkAnimation = 1,
	PlayerJumpAnimation = 2,
	PlayerDuckAnimation = 3
}

public enum PlayerState {
	Standing,
	Moving,
	Ducking,
	Jumping
}