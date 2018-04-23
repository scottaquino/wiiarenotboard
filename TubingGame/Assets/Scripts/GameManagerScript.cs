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
	public List<Image> spareTubes;

	public List<GameObject> players = new List<GameObject>();

	public bool isReady = true;
	public bool starting = false;
	bool started = false;
	public bool startLine = false;
	public int playersStarting = 0;
	public bool gucci = false;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (this.gameObject);
		titleManager = GameObject.Find ("TitleManager");
		players.Add (player1);
		players.Add (player2);
		players.Add (player3);
		players.Add (player4);
	}

	void FixedUpdate()
	{
		if (titleManager) {
			playerCount = titleManager.GetComponent<TitleManagerScript> ().playerCount;
		}
		if(startLine)
		{
			if (!isReady) {
				if (playerCount >= 2) {
					p1.gameObject.SetActive (true);
					p2.gameObject.SetActive (true);
					p3.gameObject.SetActive (false);
					p4.gameObject.SetActive (false);
				}
				if (playerCount >= 3) {
					p3.gameObject.SetActive (true);
					p4.gameObject.SetActive (false);
				}
				if (playerCount >= 4) {
					p4.gameObject.SetActive (true);
				}
				StartCoroutine (CountDown ());
			}
			if (starting) {
				readyUp.gameObject.SetActive (true);
				starting = false;
			} else if (started) {
				readyUp.gameObject.SetActive (false);
				go.gameObject.SetActive (true);
				started = false;
				StartCoroutine (CountDown2 ());
				destroyer.GetComponent<DestroyerScript> ().startingGame = true;
				gucci = true;
			}
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
