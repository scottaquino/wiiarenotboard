using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player") {
			Vector3 newPos = new Vector3 (0, col.gameObject.transform.position.y + 4.25f, -10.0f);
			transform.position = newPos;
		}
	}
}
