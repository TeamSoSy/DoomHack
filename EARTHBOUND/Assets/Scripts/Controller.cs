using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {

	public Player player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(moveRightInput()) {
			player.MoveRight();
		}
		
		if(moveLeftInput()) {
			player.MoveLeft();
		}
		
		if(duckInput()) {
			player.Duck();
		}
		
		if(moveUpInput()) {
		}
		
		if(jumpInput()) {
			player.Jump();
		}

		if (endKeyboardInput ()) {
			player.StandUp();
		}
	}

	private bool endKeyboardInput() {
		return Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.A) 
			|| Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.D) 
			|| Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.W)
			|| Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S)
				|| Input.GetKeyUp(KeyCode.Space);
	}

	private bool moveRightInput() {
		return Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D);
	}

	private bool moveLeftInput() {
		return Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.A);
	}

	private bool moveUpInput() {
		return Input.GetKey (KeyCode.UpArrow) || Input.GetKey (KeyCode.W);
	}

	private bool duckInput() {
		return Input.GetKey (KeyCode.DownArrow) || Input.GetKey (KeyCode.S);
	}

	private bool jumpInput() { 
		return Input.GetKeyUp (KeyCode.Space);
	}
}
