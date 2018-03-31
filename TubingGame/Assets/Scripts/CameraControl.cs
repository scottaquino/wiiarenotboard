using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

	public float moveSpeed;

	bool pushed = false;
	bool moving = false;
	public float speedIncrease = 1.5f;
	float pushSpeed = -1.0f;
	public float maxSpeed = 3.0f;
	Vector3 moveDirection;

	// Use this for initialization
	void Start () {
		moveDirection = new Vector3 (0f, 1f, 0f);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (!pushed && !moving) {
			transform.position += Vector3.down * moveSpeed * Time.deltaTime;
		} else if(pushed && !moving) {
			StartCoroutine (Move());
		}
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player" && col.gameObject.GetComponent<Rigidbody2D> ().velocity.y <= pushSpeed) {
			pushSpeed = col.gameObject.GetComponent<Rigidbody2D> ().velocity.y - speedIncrease;
			pushed = true;
		}
	}

	void OnTriggerExit2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player") {
			pushed = false;
		}
	}

	IEnumerator Move()
	{
		gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector3 (0f, pushSpeed, 0f);
		moving = true;
		yield return new WaitForSeconds (1.5f);
		gameObject.GetComponent<Rigidbody2D> ().velocity = Vector3.zero;
		pushSpeed = -2.0f;
		moving = false;
	}
}
