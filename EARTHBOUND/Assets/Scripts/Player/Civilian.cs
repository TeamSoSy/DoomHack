using UnityEngine;
using System.Collections;

public class Civilian : MonoBehaviour {
	
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
	
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		switch (state) {
		case PlayerState.Jumping:
			animator.SetInteger (animState, PlayerAnimState.PlayerJumpAnimation.GetHashCode());
			break;
		case PlayerState.Standing:
			animator.SetInteger (animState, PlayerAnimState.PlayerIdleAnimation.GetHashCode());
			gameObject.GetComponent<BoxCollider2D> ().size = standingBoxColliderSize;
			break;
		}
		Jump ();
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
	
	public void Jump() {
		if (onGround ()) {
			state = PlayerState.Jumping;
			ApplyForce (0, (rigidbody2D.mass * -gravityAcceleration) + jumpForce);//Cancel out gravity and apply jump force
		} else {
			state = PlayerState.Standing;
		}
	}
}