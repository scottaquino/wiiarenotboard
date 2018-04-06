using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour {

	public int playerCount;
	public GameObject destroyer;
	GameObject titleManager;
	public bool player1Win = true, player2Win = true, player3Win = true, player4Win = true;
	public Image p1, p2, p3, p4;
	public GameObject player1;
	public GameObject player2;
	public GameObject player3;
	public GameObject player4;


	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (this.gameObject);
		titleManager = GameObject.Find ("TitleManager");
		playerCount = titleManager.GetComponent<TitleManagerScript> ().playerCount;
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
		}
	}


}
