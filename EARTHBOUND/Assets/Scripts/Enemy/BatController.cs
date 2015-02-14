using UnityEngine;
using System.Collections;

public class BatController : MonoBehaviour {

	private float xVelocity = -0.2f;
	// Use this for initialization
	void Start () {
		Destroy (gameObject, 5);
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
