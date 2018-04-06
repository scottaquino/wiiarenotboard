using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

	public float moveSpeed;
	bool pushed = false;
	bool moving = false;
	public float speedIncrease = 1.5f;
	float pushSpeed = -0.5f;
	public float maxSpeed = 3.0f;
	Vector3 moveDirection;
	public GameObject manager;
    public GameObject destroyer;
	public float avgX = 0.0f;
	public float avgY = 0.0f;


	// Use this for initialization
	void Start () {
		moveDirection = new Vector3 (0f, 1f, 0f);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (!pushed && !moving) {
			Average ();
			transform.position = new Vector3(avgX, avgY - moveSpeed);
            if(!destroyer.GetComponent<DestroyerScript>().katrina)
            {
                destroyer.transform.position = transform.position;
            }
        } else if(pushed && !moving) {
			StartCoroutine (Move());
			avgX = 0.0f;
			avgY = 0.0f;
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
		gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector3 (1.0f, pushSpeed, 0f);
		moving = true;
		yield return new WaitForSeconds (1.5f);
		gameObject.GetComponent<Rigidbody2D> ().velocity = Vector3.zero;
		pushSpeed = -2.0f;
		moving = false;
	}

	void Average()
	{
		avgX = 0.0f;
		avgY = 0.0f;
		if(manager.GetComponent<GameManagerScript>().playerCount == 2) {
			avgX += manager.GetComponent<GameManagerScript> ().player1.transform.position.x;
			avgX += manager.GetComponent<GameManagerScript> ().player2.transform.position.x;
		} else if (manager.GetComponent<GameManagerScript>().playerCount == 3) {
			avgX += manager.GetComponent<GameManagerScript> ().player1.transform.position.x;
			avgX += manager.GetComponent<GameManagerScript> ().player2.transform.position.x;
			avgX += manager.GetComponent<GameManagerScript> ().player3.transform.position.x;
		} else if(manager.GetComponent<GameManagerScript>().playerCount == 4) {
			avgX += manager.GetComponent<GameManagerScript> ().player1.transform.position.x;
			avgX += manager.GetComponent<GameManagerScript> ().player2.transform.position.x;
			avgX += manager.GetComponent<GameManagerScript> ().player3.transform.position.x;
			avgX += manager.GetComponent<GameManagerScript> ().player4.transform.position.x;
		}
		avgX /= manager.GetComponent<GameManagerScript> ().playerCount;
		//Debug.Log (avgX);
		if(manager.GetComponent<GameManagerScript>().playerCount == 2) {
			avgY += manager.GetComponent<GameManagerScript> ().player1.transform.position.y;
			avgY += manager.GetComponent<GameManagerScript> ().player2.transform.position.y;
		} else if (manager.GetComponent<GameManagerScript>().playerCount == 3) {
			avgY += manager.GetComponent<GameManagerScript> ().player1.transform.position.y;
			avgY += manager.GetComponent<GameManagerScript> ().player2.transform.position.y;
			avgY += manager.GetComponent<GameManagerScript> ().player3.transform.position.y;
		} else if(manager.GetComponent<GameManagerScript>().playerCount == 4) {
			avgY += manager.GetComponent<GameManagerScript> ().player1.transform.position.y;
			avgY += manager.GetComponent<GameManagerScript> ().player2.transform.position.y;
			avgY += manager.GetComponent<GameManagerScript> ().player3.transform.position.y;
			avgY += manager.GetComponent<GameManagerScript> ().player4.transform.position.y;
		}
		avgY /= manager.GetComponent<GameManagerScript> ().playerCount;
		//Debug.Log (avgY);
	}
}
