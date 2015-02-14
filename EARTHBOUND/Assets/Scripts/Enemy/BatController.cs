using UnityEngine;
using System.Collections;

public class BatController : MonoBehaviour {

	public float xVelocity;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (new Vector3(xVelocity, 0));
	}

	void OnTriggerEnter2D( Collider2D collidedObject )
	{   if (collidedObject.name.Equals ("Player")) {
			Debug.LogError ("asdf");
		}
	}  
}
