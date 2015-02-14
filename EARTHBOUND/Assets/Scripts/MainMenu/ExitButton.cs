using UnityEngine;
using System.Collections;

public class ExitButton : MonoBehaviour {
	
	public string scene;
	
	private bool loadLock;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnMouseOver() {
		gameObject.GetComponent<Animator> ().SetBool ("isMouseOver", true);
	}
	
	void OnMouseExit() {
		gameObject.GetComponent<Animator> ().SetBool ("isMouseOver", false);
	}
	
	void OnMouseDown() {
		if(!loadLock) {
			loadLock = true;
			Application.Quit();
		}
	}
}
