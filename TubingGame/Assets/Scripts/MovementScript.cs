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
	}
	
	// Update is called once per frame
	void Update () {
		GetInput();
		ProcessInput();
	}

	void GetInput()
	{
		// Get the input from the Rewired Player. All controllers that the Player owns will contribute, so it doesn't matter
		// whether the input is coming from a joystick, the keyboard, mouse, or a custom controller.

		moveVector.y = player.GetAxis ("Vertical") * moveSpeed - gravity;
		moveVector.x = player.GetAxis("Horizontal") * moveSpeed; // get input by name or action id
	}
	 
	void ProcessInput()
	{
		// Process movement
		if(moveVector.x != 0.0f || moveVector.y != 0.0f) {
			if(gameObject.GetComponent<Rigidbody2D>().velocity.magnitude >= maxSpeed)
			{
				gameObject.GetComponent<Rigidbody2D> ().velocity = gameObject.GetComponent<Rigidbody2D> ().velocity.normalized * maxSpeed;
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
        StartCoroutine("Bounce");
    }

    IEnumerator Bounce()
    {
        for(int i = 0; i < 5; i++)
        {
            Debug.Log("BOUNCING");
            gameObject.GetComponent<Rigidbody2D>().AddForce(-moveVector * bounce * moveSpeed); //bounce math
            yield return new WaitForSeconds(1.0f);
        }
    }

}  
 