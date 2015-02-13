using UnityEngine;
using System.Collections;

public class HealthChange : MonoBehaviour {

	public int healthChange;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D( Collider2D collidedObject )
	{   if (collidedObject.name.Equals ("Player")) {
			Debug.LogError ("HP + " + healthChange + " from " + this.name + " (not implemented yet)");
			collidedObject.SendMessage ("changeHP", healthChange);
		}
	}   

}
