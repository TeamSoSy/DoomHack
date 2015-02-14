using UnityEngine;
using System.Collections;

public class FlyController1 : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate() {
		int variableySpeedMultiplier = Random.Range (0, 10);
		int variablexSpeedMultiplie = Random.Range (0, 100);
		transform.Translate(new Vector3(0.01f*(variablexSpeedMultiplie-50), -0.01f*variableySpeedMultiplier, 0));
	}
}
