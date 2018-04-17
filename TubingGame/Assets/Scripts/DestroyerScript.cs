using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyerScript : MonoBehaviour {

	public int numPlayers;
	public float deathTimer;
	public bool katrina = false;
	public float stormSpeed;
	public GameObject manager;

	// Use this for initialization
	void Start () {
		StartCoroutine (CatchUp());
		numPlayers = manager.GetComponent<GameManagerScript>().playerCount;

	}

	// Update is called once per frame
	void FixedUpdate () {
		if(katrina)
		{
			gameObject.transform.position = new Vector3(gameObject.GetComponentInParent<Transform>().transform.position.x,
				gameObject.GetComponentInParent<Transform>().transform.position.y - stormSpeed);
		}
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		//Debug.Log (col.gameObject.tag);
		//Debug.Log (numPlayers);
		if (col.gameObject.tag == "Player" && numPlayers > 1) {
			//Debug.Log("HEY THERE");
			if (!col.gameObject.GetComponent<MovementScript> ().hasSpare) {
				if (col.gameObject.GetComponent<MovementScript> ().playerId == 0) {
					manager.GetComponent<GameManagerScript> ().player1Win = false;
					for (int i = 0; i < gameObject.GetComponentInParent<CameraControl> ().players.Count; i++) {
						if (gameObject.GetComponentInParent<CameraControl> ().players [i]) {
							if (gameObject.GetComponentInParent<CameraControl> ().players [i].GetComponent<MovementScript> ().playerId == 0) {
								gameObject.GetComponentInParent<CameraControl> ().players.RemoveAt (i);
							}
						}
					}
					manager.GetComponent<GameManagerScript> ().p1.gameObject.SetActive (false);
				} else if (col.gameObject.GetComponent<MovementScript> ().playerId == 1) {
					manager.GetComponent<GameManagerScript> ().player2Win = false;
					for (int i = 0; i < gameObject.GetComponentInParent<CameraControl> ().players.Count; i++) {
						if (gameObject.GetComponentInParent<CameraControl> ().players [i]) {
							if (gameObject.GetComponentInParent<CameraControl> ().players [i].GetComponent<MovementScript> ().playerId == 1) {
								gameObject.GetComponentInParent<CameraControl> ().players.RemoveAt (i);
							}
						}
					}
					manager.GetComponent<GameManagerScript> ().p2.gameObject.SetActive (false);
				} else if (col.gameObject.GetComponent<MovementScript> ().playerId == 2) {
					manager.GetComponent<GameManagerScript> ().player3Win = false;
					for (int i = 0; i < gameObject.GetComponentInParent<CameraControl> ().players.Count; i++) {
						if (gameObject.GetComponentInParent<CameraControl> ().players [i]) {
							if (gameObject.GetComponentInParent<CameraControl> ().players [i].GetComponent<MovementScript> ().playerId == 2) {
								gameObject.GetComponentInParent<CameraControl> ().players.RemoveAt (i);
							}
						}
					}
					manager.GetComponent<GameManagerScript> ().p3.gameObject.SetActive (false);
				} else if (col.gameObject.GetComponent<MovementScript> ().playerId == 3) {
					manager.GetComponent<GameManagerScript> ().player4Win = false;
					for (int i = 0; i < gameObject.GetComponentInParent<CameraControl> ().players.Count; i++) {
						if (gameObject.GetComponentInParent<CameraControl> ().players [i]) {
							if (gameObject.GetComponentInParent<CameraControl> ().players [i].GetComponent<MovementScript> ().playerId == 3) {
								gameObject.GetComponentInParent<CameraControl> ().players.RemoveAt (i);
							}
						}
					}
					manager.GetComponent<GameManagerScript> ().p4.gameObject.SetActive (false);
				}
				gameObject.GetComponentInParent<CameraControl> ().someoneDied = true;
				Destroy (col.gameObject);
				//Debug.Log ("WORKING???");
				manager.GetComponent<GameManagerScript> ().playerCount--;
				numPlayers--;
				// Debug.Log(numPlayers);
				if (numPlayers == 1)
					EndGame ();
			} else {
				col.gameObject.GetComponent<MovementScript> ().hasSpare = false;
				col.gameObject.transform.position = GameObject.Find ("MainCamera").transform.position;
			}
			
		}
	}

	void EndGame()
	{
		SceneManager.LoadScene ("YouWin");
	}

	IEnumerator CatchUp()
	{
		yield return new WaitForSeconds (deathTimer);
		katrina = true;
	}
}
