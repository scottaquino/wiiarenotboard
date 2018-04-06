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
	float prevX = 0.0f;
	float prevY = 0.0f;
	public bool someoneDied = false;
	public int moveCounter = 0;

	float startTime;
	float journeyDist;
	public float speed = 1.0f;
	float distCovered;
	float fracJourney;
	Transform startPos;

	public List<GameObject> players = new List<GameObject>();


	// Use this for initialization
	void Start () {
		moveDirection = new Vector3 (0f, 1f, 0f);
		startTime = Time.deltaTime;
		startPos = gameObject.transform;
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (!someoneDied) {
			Average ();
			transform.position = new Vector3 (avgX, avgY - moveSpeed);
		} else {
			if(moveCounter == 0) {
				startTime = Time.deltaTime;
				journeyDist = Vector3.Distance (new Vector3(prevX, prevY), new Vector3(avgX, avgY));
				startPos.position = new Vector3 (prevX, prevY - moveSpeed);
				startTime = 0.0f;
			}
			distCovered = (Time.deltaTime - startTime) * speed;
			fracJourney = distCovered / journeyDist;
			Move ();
			if(moveCounter >= 10) {
				someoneDied = false;
				moveCounter = 0;
			}
		}
		if (!destroyer.GetComponent<DestroyerScript> ().katrina) {
			destroyer.transform.position = transform.position;
		}
	}

	void OnTriggerExit2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player") {
			pushed = false;
		}
	}

	void Move()
	{
		Average ();
		transform.position = Vector3.Lerp (startPos.position, new Vector3(avgX, avgY - moveSpeed), fracJourney);
		moveCounter++;
	}

	void Average()
	{
		prevX = avgX;
		prevY = avgY;
		avgX = 0.0f;
		avgY = 0.0f;
		if(manager.GetComponent<GameManagerScript>().playerCount == 2) {
			avgX += players[0].transform.position.x;
			avgX += players[1].transform.position.x;
		} else if (manager.GetComponent<GameManagerScript>().playerCount == 3) {
			avgX += players[0].transform.position.x;
			avgX += players[1].transform.position.x;
			avgX += players[2].transform.position.x;
		} else if(manager.GetComponent<GameManagerScript>().playerCount == 4) {
			avgX += players[0].transform.position.x;
			avgX += players[1].transform.position.x;
			avgX += players[2].transform.position.x;
			avgX += players[3].transform.position.x;
		}
		avgX /= manager.GetComponent<GameManagerScript> ().playerCount;
		//Debug.Log (avgX);
		if(manager.GetComponent<GameManagerScript>().playerCount == 2) {
			avgY += players[0].transform.position.y;
			avgY += players[1].transform.position.y;
		} else if (manager.GetComponent<GameManagerScript>().playerCount == 3) {
			avgY += players[0].transform.position.y;
			avgY += players[1].transform.position.y;
			avgY += players[2].transform.position.y;
		} else if(manager.GetComponent<GameManagerScript>().playerCount == 4) {
			avgY += players[0].transform.position.y;
			avgY += players[1].transform.position.y;
			avgY += players[2].transform.position.y;
			avgY += players[3].transform.position.y;
		}
		avgY /= manager.GetComponent<GameManagerScript> ().playerCount;
		//Debug.Log (avgY);
	}
}
