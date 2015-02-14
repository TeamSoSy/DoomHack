using UnityEngine;
using System.Collections;

public class HealthChange : MonoBehaviour {
	public Collider2D other;
	public int healthChange;
	private bool hit = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D( Collider2D collidedObject )
	{   if (collidedObject.name.Equals (other.name)) {
			Debug.LogError ("HP + " + healthChange + " from " + this.name);
			if (!hit){
				hit=true;
			collidedObject.SendMessage ("changeHP", healthChange);

			}
		}
	}   

}
