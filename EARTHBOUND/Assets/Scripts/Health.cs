using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
	public int HP;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void changeHP(int HP){
		this.HP += HP; 
		Debug.Log (this.name + " health:" + this.HP);
		if (this.HP <= 0) {
			Destroy (gameObject);
			Debug.Log (this.name + "destroyed");
		}
	}
}
