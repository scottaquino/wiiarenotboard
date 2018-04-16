using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleManagerScript : MonoBehaviour {

	public int playerCount;
	public GameObject numOfPlayersNew;
	public GameObject player1;
	public GameObject player2;
	public GameObject player3;
	public GameObject player4;

	GameObject manager;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (this.gameObject);
		manager = GameObject.Find ("GameManager");
		if (manager) {
			Destroy (manager);
		}
	}
	
	// Update is called once per frame
	void Update () {
		numOfPlayersNew.GetComponent<TextMesh>().text = playerCount.ToString ();
		if(playerCount == 2)
		{
			player1.gameObject.SetActive (true);
			player2.gameObject.SetActive (true);
			player3.gameObject.SetActive (false);
			player4.gameObject.SetActive (false);
		}
		if(playerCount == 3)
		{
			player1.gameObject.SetActive (true);
			player2.gameObject.SetActive (true);
			player3.gameObject.SetActive (true);
			player4.gameObject.SetActive (false);
		}
		if(playerCount == 4)
		{
			player1.gameObject.SetActive (true);
			player2.gameObject.SetActive (true);
			player3.gameObject.SetActive (true);
			player4.gameObject.SetActive (true);
		}
	}

	public void StartButton()
	{
		SceneManager.LoadScene ("Main");
	}

	public void AddPlayers()
	{
		if(playerCount < 4)
		{
			playerCount++;
		}
	}

	public void RemovePlayers()
	{
		if(playerCount > 2)
		{
			playerCount--;
		}
	}
}
