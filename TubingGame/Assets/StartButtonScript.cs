using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButtonScript : MonoBehaviour {

	public GameObject manager;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay2D(Collider2D col)
	{
		if (Input.GetKeyDown (KeyCode.Space)) {
			manager.GetComponent<TitleManagerScript> ().StartButton ();
		}
	}
}
