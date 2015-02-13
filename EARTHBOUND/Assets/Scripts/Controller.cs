using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {

	public Player player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) {
			player.MoveRight();
		}
		
		if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) {
			player.MoveLeft();
		}
		
		if(Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) {
			player.Duck();
		}
		
		if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) {
		}
		
		if(Input.GetKeyUp(KeyCode.Space)) {
			player.Jump();
		}
	}
}
