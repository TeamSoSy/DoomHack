using UnityEngine;
using System.Collections;

public class CheckboxButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnMouseDown() {
		gameObject.GetComponent<Animator> ().SetBool ("isClicked", true);
	}
}
