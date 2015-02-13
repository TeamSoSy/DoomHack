using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	public GameObject followedObject;
	
//	void Awake(){
//		camera.orthographicSize = ((Screen.height / 2.0f) / 100f);
//	}
	// Use this for initialization
	void Start () {

	}
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (followedObject.transform.position.x, followedObject.transform.position.y, transform.position.z);
	}
}
