using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLineScript : MonoBehaviour {
	public GameObject manager;
	bool started = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (!started) {
			for (int i = 0; i < manager.GetComponent<GameManagerScript> ().playerCount; i++) {
				if (manager.GetComponent<GameManagerScript> ().players [i].GetComponent<Transform> ().transform.position.y <= gameObject.transform.position.y) {
					manager.GetComponent<GameManagerScript> ().players [i].GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeAll;
					manager.GetComponent<GameManagerScript> ().players [i].GetComponent<MovementScript> ().freeze = true;
				}
				if (manager.GetComponent<GameManagerScript> ().players [i].GetComponent<MovementScript> ().freeze == true &&
				   manager.GetComponent<GameManagerScript> ().players [i].GetComponent<MovementScript> ().frozen == false) {
					manager.GetComponent<GameManagerScript> ().players [i].GetComponent<MovementScript> ().frozen = true;
					manager.GetComponent<GameManagerScript> ().playersStarting++;
				}
			}
			if (manager.GetComponent<GameManagerScript> ().playersStarting >= manager.GetComponent<GameManagerScript> ().playerCount) {
				manager.GetComponent<GameManagerScript> ().startLine = true;
				started = true;
			}
		}
	}
}
