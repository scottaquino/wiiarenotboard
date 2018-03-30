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
	}
	
	// Update is called once per frame
	void Update () {
		if(katrina)
		{
			transform.position = new Vector3 (0.0f, gameObject.transform.position.y - stormSpeed * 0.01f, 0.0f);
		}
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player" && numPlayers > 1) {
			if (col.gameObject.GetComponent<MovementScript>().playerId == 0)
			{
				manager.GetComponent<GameManagerScript> ().player1Win = false;
				manager.GetComponent<GameManagerScript> ().p1.gameObject.SetActive (false);
			}
			else if (col.gameObject.GetComponent<MovementScript>().playerId == 1)
			{
				manager.GetComponent<GameManagerScript> ().player2Win = false;
				manager.GetComponent<GameManagerScript> ().p2.gameObject.SetActive (false);
			}
			else if (col.gameObject.GetComponent<MovementScript>().playerId == 2)
			{
				manager.GetComponent<GameManagerScript> ().player3Win = false;
				manager.GetComponent<GameManagerScript> ().p3.gameObject.SetActive (false);
			}
			else if (col.gameObject.GetComponent<MovementScript>().playerId == 3)
			{
				manager.GetComponent<GameManagerScript> ().player4Win = false;
				manager.GetComponent<GameManagerScript> ().p4.gameObject.SetActive (false);
			}
			Destroy (col.gameObject);
			numPlayers--;
			if (numPlayers == 1)
				EndGame ();
		}
	}

	void OnTriggerExit2D(Collider2D col)
	{
		if (col.gameObject.tag == "River")
			Destroy (col.gameObject);
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
