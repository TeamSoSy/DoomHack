using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float acceleration = 10f;
	public float jumpForce = 100;
	public float maxSpeed = 10f;

	private float gravityAcceleration = -9.8f;
	private Animator animator;
	private const string animState = "AnimState"; //This should probably be a constant somewhere throughout app
	private PlayerState state;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

		if(state != PlayerState.Ducking && rigidbody2D.velocity.x == 0 && rigidbody2D.velocity.y == 0) {
			state = PlayerState.Standing;
		}

		switch (state) {
		case PlayerState.Moving:
			animator.SetInteger (animState, AnimationState.PlayerWalkAnimation.GetHashCode());
			transform.localScale = new Vector3 (rigidbody2D.velocity.x > 0 ? 1 : -1, 1);
			break;
		case PlayerState.Ducking:
			animator.SetInteger (animState, AnimationState.PlayerDuckAnimation.GetHashCode());
			break;
		case PlayerState.Jumping:
			animator.SetInteger (animState, AnimationState.PlayerJumpAnimation.GetHashCode());
			break;
		default:
			animator.SetInteger (animState, AnimationState.PlayerIdleAnimation.GetHashCode());
			break;
		}
	}

	public void ApplyForce(float forceX, float forceY) {
		rigidbody2D.AddForce(new Vector2(forceX, forceY));
	}

	public void StandUp() {
		state = PlayerState.Standing;
	}

	public void Duck() {
		state = PlayerState.Ducking;
	}

	public void Jump() {
		ApplyForce(0, (rigidbody2D.mass * -gravityAcceleration) + jumpForce);//Cancel out gravity and apply jump force
		state = PlayerState.Jumping;
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
public enum AnimationState {
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