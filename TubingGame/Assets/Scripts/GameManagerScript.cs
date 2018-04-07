using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Rewired;

public class GameManagerScript : MonoBehaviour {

	public int playerCount;
	public GameObject destroyer;
	GameObject titleManager;
	public bool player1Win = true, player2Win = true, player3Win = true, player4Win = true;
	public Image p1, p2, p3, p4;
	public Text readyUp, go;
	public GameObject player1;
	public GameObject player2;
	public GameObject player3;
	public GameObject player4;
	public GameObject camera;

	public List<GameObject> players = new List<GameObject>();

	public bool isReady = false;
	bool starting = false;
	bool started = false;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (this.gameObject);
		titleManager = GameObject.Find ("TitleManager");
		if (titleManager) {
			playerCount = titleManager.GetComponent<TitleManagerScript> ().playerCount;
			Destroy (titleManager);
		}
		if(playerCount == 1)
		{
			player1.SetActive (true);
			player2.SetActive (false);
			player3.SetActive (false);
			player4.SetActive (false);
			p1.gameObject.SetActive (true);
			p2.gameObject.SetActive (false);
			p3.gameObject.SetActive (false);
			p4.gameObject.SetActive (false);
			players.Add (player1);
		}
		if(playerCount == 2)
		{
			player1.SetActive (true);
			player2.SetActive (true);
			player3.SetActive (false);
			player4.SetActive (false);
			p1.gameObject.SetActive (true);
			p2.gameObject.SetActive (true);
			p3.gameObject.SetActive (false);
			p4.gameObject.SetActive (false);
			players.Add (player1);
			players.Add (player2);
		}
		if(playerCount == 3)
		{
			player1.SetActive (true);
			player2.SetActive (true);
			player3.SetActive (true);
			player4.SetActive (false);
			p1.gameObject.SetActive (true);
			p2.gameObject.SetActive (true);
			p3.gameObject.SetActive (true);
			p4.gameObject.SetActive (false);
			players.Add (player1);
			players.Add (player2);
			players.Add (player3);
		}
		if(playerCount == 4)
		{
			player1.SetActive (true);
			player2.SetActive (true);
			player3.SetActive (true);
			player4.SetActive (true);
			p1.gameObject.SetActive (true);
			p2.gameObject.SetActive (true);
			p3.gameObject.SetActive (true);
			p4.gameObject.SetActive (true);
			players.Add (player1);
			players.Add (player2);
			players.Add (player3);
			players.Add (player4);
		}

		for(int i = 0; i < playerCount; i++)
		{
			players [i].GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeAll;
		}
	}

	void FixedUpdate()
	{
		if (!isReady) {
			StartCoroutine(CountDown ());
			for(int i = 0; i < playerCount; i++)
			{
				players [i].GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeAll;
			}
		}
		if (starting) {
			readyUp.gameObject.SetActive (true);
			starting = false;
		} else if (started) {
			readyUp.gameObject.SetActive (false);
			go.gameObject.SetActive (true);
			started = false;
			StartCoroutine (CountDown2 ());
		}

	}

	IEnumerator CountDown()
	{
		isReady = true;
		starting = true;
		yield return new WaitForSeconds (3.0f);
		for(int i = 0; i < playerCount; i++)
		{
			players [i].GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.None;
			players [i].GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeRotation;
		}
		started = true;
	}

	IEnumerator CountDown2()
	{
		yield return new WaitForSeconds (0.75f);
		go.gameObject.SetActive (false);
	}

}
