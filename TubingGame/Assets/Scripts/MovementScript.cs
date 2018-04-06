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

	public GameObject manager;

	public GameObject otherPlayer1;
	public GameObject otherPlayer2;
	public GameObject otherPlayer3;

	public bool first;

	private Player player; // The Rewired Player
	//private CharacterController cc;
	private Vector3 moveVector; 

	void Awake() {
		// Get the Rewired Player object for this player and keep it for the duration of the character's lifetime
		player = ReInput.players.GetPlayer(playerId);

		// Get the character controller
		//cc = gameObject.GetComponent<CharacterController>();
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
		CheckFirst ();
	}

	void GetInput()
	{
		// Get the input from the Rewired Player. All controllers that the Player owns will contribute, so it doesn't matter
		// whether the input is coming from a joystick, the keyboard, mouse, or a custom controller.

		if(!bouncing)
		{
			moveVector.y = player.GetAxis ("Vertical") * moveSpeed - gravity;
			moveVector.x = player.GetAxis("Horizontal") * moveSpeed; // get input by name or action id
		}
	}
	 
	void ProcessInput()
	{
		// Process movement
		if(moveVector.x != 0.0f || moveVector.y != 0.0f) {
			if(GetComponent<Rigidbody2D>().velocity.magnitude > maxSpeed)
			{
				GetComponent<Rigidbody2D> ().velocity = GetComponent<Rigidbody2D> ().velocity.normalized * maxSpeed;
			}
			if(moveVector.y >= -1.0f)
			{
				moveVector.y = 0.2f;
			}
			gameObject.GetComponent<Rigidbody2D>().AddForce(moveVector * moveSpeed);
		} 
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("COLLIDING");
		StartCoroutine(Bounce(collision));
    }

	IEnumerator Bounce(Collision2D col)
    {
        Debug.Log("BOUNCING");
        gameObject.GetComponent<Rigidbody2D>().AddForce(-moveVector * bounce/2 * moveSpeed); //bounce math for aggressor
		col.gameObject.GetComponent<Rigidbody2D>().AddForce(moveVector * bounce * moveSpeed); //bounce math for person getting bumped

		//Take away control of movement during bounce
		bouncing = true;
		gameObject.GetComponent<Rigidbody2D> ().velocity = Vector3.zero;
		moveVector.x = 0.0f;
		moveVector.y = 0.0f;
		yield return new WaitForSeconds(bounceControl);
		bouncing = false;
    }

	void CheckFirst()
	{
		if(manager.GetComponent<GameManagerScript>().playerCount == 2) {
			if (gameObject.transform.position.y < otherPlayer1.transform.position.y) {
				first = true;
			} else {
				first = false;
			}
		} else if(manager.GetComponent<GameManagerScript>().playerCount == 3) {
			if (gameObject.transform.position.y < otherPlayer1.transform.position.y && gameObject.transform.position.y < otherPlayer2.transform.position.y) {
				first = true;
			} else {
				first = false;
			}
		} else if(manager.GetComponent<GameManagerScript>().playerCount == 4) {
			if (gameObject.transform.position.y < otherPlayer1.transform.position.y && gameObject.transform.position.y < otherPlayer2.transform.position.y && gameObject.transform.position.y < otherPlayer3.transform.position.y) {
				first = true;
			} else {
				first = false;
			}
		}

		if(first) {
			//Debug.Log(gameObject);
		}
	}

}  
 