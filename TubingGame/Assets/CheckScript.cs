using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckScript : MonoBehaviour {

	GameObject player1;
	GameObject player2;
	GameObject player3;
	GameObject player4;

	// Use this for initialization
	void Start () {
		player1 = GameObject.Find("Player");
		player2 = GameObject.Find("Player2");
		player3 = GameObject.Find("Player3");
		player4 = GameObject.Find ("Player4");

		Debug.Log (player1);
		Debug.Log (player2);
		Debug.Log (player3);
		Debug.Log (player4);
	}
	
	// Update is called once per frame
	void FixedUpdate () {

	}

	public void SetPlayers()
	{
		if(gameObject == player1)
		{
			gameObject.GetComponent<MovementScript> ().otherPlayer1 = player2;
			gameObject.GetComponent<MovementScript> ().otherPlayer2 = player3;
			gameObject.GetComponent<MovementScript> ().otherPlayer3 = player4;
			Debug.Log ("Player1 Init");
		}
		else if(gameObject == player2)
		{
			gameObject.GetComponent<MovementScript> ().otherPlayer1 = player1;
			gameObject.GetComponent<MovementScript> ().otherPlayer2 = player3;
			gameObject.GetComponent<MovementScript> ().otherPlayer3 = player4;
			Debug.Log ("Player2 Init");
		}
		else if(gameObject == player3)
		{
			gameObject.GetComponent<MovementScript> ().otherPlayer1 = player1;
			gameObject.GetComponent<MovementScript> ().otherPlayer2 = player2;
			gameObject.GetComponent<MovementScript> ().otherPlayer3 = player4;
			Debug.Log ("Player3 Init");
		}
		else if(gameObject == player4)
		{
			gameObject.GetComponent<MovementScript> ().otherPlayer1 = player1;
			gameObject.GetComponent<MovementScript> ().otherPlayer2 = player2;
			gameObject.GetComponent<MovementScript> ().otherPlayer3 = player3;
			Debug.Log ("Player4 Init");
		}

	}
}
