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
		GameObject healthbar = GameObject.Find ("hp");
		healthbar.transform.localScale += new Vector3(-0.1f,0f,0f);
		if (this.HP <= 0) {
			Application.LoadLevel ("GameOver");
//			Destroy (gameObject);
			Debug.Log (this.name + "destroyed");
		}
	}
}
