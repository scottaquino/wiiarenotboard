using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class MovementScript : MonoBehaviour {

	public int playerId = 0; // The Rewired player id of this character

	public float moveSpeed = 3.0f;
	public float maxSpeed = 3.0f;
	public float gravity = 2.0f;
	public float bounce = 15.0f;
	public float bounceControl = 0.1f;
	bool bouncing = false;
	bool isFirst = false;
	public bool freeze = false;
	public bool frozen = false;
	public bool hasSpare = false;
	public bool hasItem = false;

	public Sprite leanRight;
	public Sprite leanLeft;
	public Sprite centered;
	public GameObject character;

	public GameObject manager;
	public GameObject camera;

	public GameObject otherPlayer1;
	public GameObject otherPlayer2;
	public GameObject otherPlayer3;

	public bool first;
	public float firstPenalty = 1.0f;

	public Player player; // The Rewired Player
	//private CharacterController cc;
	public Vector3 moveVector; 

	void Awake() {
		// Get the Rewired Player object for this player and keep it for the duration of the character's lifetime
		player = ReInput.players.GetPlayer(playerId);
	}

	// Use this for initialization
	void Start () {
		moveVector.y = -1.1f;
		gameObject.GetComponent<CheckScript> ().SetPlayers ();
	}

	// Update is called once per frame
	void FixedUpdate () {
		GetInput();
		ProcessInput();
		if (hasSpare) {
			manager.GetComponent<GameManagerScript> ().spareTubes [playerId].gameObject.SetActive (true);
		} else {
			manager.GetComponent<GameManagerScript> ().spareTubes [playerId].gameObject.SetActive (false);
		}
	}

	void GetInput()
	{
		// Get the input from the Rewired Player. All controllers that the Player owns will contribute, so it doesn't matter
		// whether the input is coming from a joystick, the keyboard, mouse, or a custom controller.
		if (!bouncing) {
			moveVector.y = player.GetAxis ("Vertical") * moveSpeed - gravity;
			moveVector.x = player.GetAxis ("Horizontal") * moveSpeed; // get input by name or action id
		}
	}

	void ProcessInput()
	{
		// Process movement
		if (manager) {
			first = CheckFirst ();
		}
		if (first) {
			firstPenalty = 0.75f;
		} else {
			firstPenalty = 1.0f;
		}
		if(moveVector.x != 0.0f || moveVector.y != 0.0f) {
			if(GetComponent<Rigidbody2D>().velocity.magnitude > maxSpeed)
			{
				GetComponent<Rigidbody2D> ().velocity = GetComponent<Rigidbody2D> ().velocity.normalized * maxSpeed;
			}
			if(moveVector.y >= -1.0f)
			{
				moveVector.y = 0.2f;
			}
			gameObject.GetComponent<Rigidbody2D>().AddForce(moveVector * moveSpeed * firstPenalty);
		} 
		if (moveVector.x >= 1.0) {
			character.GetComponent<SpriteRenderer> ().sprite = leanRight;
		} else if (moveVector.x <= -1.0) {
			character.GetComponent<SpriteRenderer> ().sprite = leanLeft;
		} else {
			character.GetComponent<SpriteRenderer> ().sprite = centered;
		}
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		Debug.Log("COLLIDING");
		if (collision.gameObject.tag == "Player") {
			StartCoroutine (Bounce (collision));
		} else {
			StartCoroutine (BounceObject (collision));
		}
	}

	IEnumerator Bounce(Collision2D col)
	{
		Debug.Log("BOUNCING");
		//gameObject.GetComponent<Rigidbody2D>().AddForce(-moveVector * bounce/2 * moveSpeed); //bounce math for aggressor
		col.gameObject.GetComponent<Rigidbody2D>().AddForce(moveVector * bounce * moveSpeed); //bounce math for person getting bumped

		//Take away control of movement during bounce
		bouncing = true;
		gameObject.GetComponent<Rigidbody2D> ().velocity = Vector3.zero;
		moveVector.x = 0.0f;
		moveVector.y = 0.0f;
		yield return new WaitForSeconds(bounceControl);
		bouncing = false;
	}

	IEnumerator BounceObject(Collision2D col)
	{
		bouncing = true;
		gameObject.GetComponent<Rigidbody2D> ().AddForce (-moveVector);
		moveVector.x = 0.0f;
		moveVector.y = 0.0f;
		yield return new WaitForSeconds(0.2f);
		bouncing = false;
	}

	bool CheckFirst()
	{
		for(int i = 0; i < manager.GetComponent<GameManagerScript>().playerCount; i++)
		{
			if (gameObject.transform.position.y <= camera.GetComponent<CameraControl> ().players [i].transform.position.y) {
				isFirst = true;
			} else {
				isFirst = false;
				return isFirst;
			}
		}
		return isFirst;
	}

}  
