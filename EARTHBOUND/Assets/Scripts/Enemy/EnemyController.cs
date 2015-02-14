using UnityEngine;
using System.Collections;

public class HorizontalEnemyController : MonoBehaviour {
	public Transform sightStart, sightEnd;
	public float walkingSpeed = 0.05f;
	private bool collision;
	private Vector2 emptyLocation;
	private int directionMultiplier;
	// Use this for initialization
	void Start () {
		directionMultiplier = 1;

	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (new Vector3(walkingSpeed*directionMultiplier, 0));
//		Debug.Log (transform.localPosition);
		collision = Physics2D.Linecast (transform.position, getPositionOfLedge (), 1 << LayerMask.NameToLayer ("Solid"));
		if (!collision) {
			directionMultiplier *= -1;
		}
//		Debug.Log (collision);
//		Debug.DrawLine (transform.position, getPosition(), Color.yellow);
	}

	Vector2 getPositionOfLedge(){
		return new Vector2(transform.position.x + 1*directionMultiplier, transform.position.y - 1);
	}

}
