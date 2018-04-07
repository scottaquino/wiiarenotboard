using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleManagerScript : MonoBehaviour {

	public int playerCount = 2;
	public Text numOfPlayers;

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
		if(numOfPlayers) {
			numOfPlayers.text = playerCount.ToString ();
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
