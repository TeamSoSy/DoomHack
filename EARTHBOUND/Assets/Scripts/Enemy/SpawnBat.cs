using UnityEngine;
using System.Collections;

public class SpawnBat : MonoBehaviour {

	public Transform bat;
	public GameObject player;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D( Collider2D collidedObject ) {
		Instantiate (bat, new Vector3 (player.transform.position.x+10, player.transform.position.y, 0), Quaternion.identity);
		Debug.Log ("hi");
	}
}
