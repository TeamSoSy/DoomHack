using UnityEngine;
using System.Collections;

public class LoadScene : MonoBehaviour {
	public string scene;
	private bool loadLock = false;

	void OnTriggerEnter2D(Collider2D objectFound) {
		if (objectFound.name.Equals("Player")) {
			Debug.Log("player found");
			if(!loadLock) {
				loadLock = true;
				Application.LoadLevel(scene);
			}
		}
	}
}
