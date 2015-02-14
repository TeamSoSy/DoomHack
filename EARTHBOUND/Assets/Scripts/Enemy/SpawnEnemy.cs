using UnityEngine;
using System.Collections;

public class SpawnEnemy : MonoBehaviour {
	public int x;
	public int y;
	public Transform enemy;
	public GameObject player;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D( Collider2D collidedObject ) {
		Instantiate (enemy, new Vector3 (player.transform.position.x+x, player.transform.position.y+y, 0), Quaternion.identity);
	}
}
