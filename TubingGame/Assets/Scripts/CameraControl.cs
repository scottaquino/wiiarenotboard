using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

	public float moveSpeed;

	bool pushed = false;
	float pushSpeed = -2.0f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (!pushed)
			transform.position += Vector3.down * moveSpeed * Time.deltaTime;
		else
			transform.position += Vector3.down * -pushSpeed * Time.deltaTime;
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player" && col.gameObject.GetComponent<Rigidbody2D> ().velocity.y <= pushSpeed) {
			pushed = true;
			pushSpeed = col.gameObject.GetComponent<Rigidbody2D> ().velocity.y;
		}
	}

	void OnTriggerExit2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player") {
			pushed = false;
			pushSpeed = -2.0f;
		}
	}
}
