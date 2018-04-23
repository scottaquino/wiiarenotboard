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
	public GameObject[] buttons;
	GameObject current;
	int index = 1;
	public GameObject pointer;
	public GameObject startingStuff;

	public GameObject manager;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (this.gameObject);
		startingStuff.gameObject.SetActive (true);
		//if (manager) {
			//Destroy (manager);
		//}
		index = 0;
		current = buttons [index];
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
		if (Input.GetKeyDown (KeyCode.A) && index > 0)
		{
			current = buttons [--index];
			//Debug.Log ("AAAAAAAAAAAAA");
		}
		if(Input.GetKeyDown (KeyCode.D) && index < 2)
		{
			current = buttons[++index];
		}
		if(Input.GetKeyDown (KeyCode.S))
		{
			switch(index)
			{
			case 0:
				RemovePlayers ();
				break;
			case 1:
				StartButton ();
				break;
			case 2:
				AddPlayers ();
				break;
			}
		}
		pointer.gameObject.transform.position = new Vector3 (current.gameObject.transform.position.x, 
			current.gameObject.transform.position.y + 1.0f, current.gameObject.transform.position.z);
	}

	public void StartButton()
	{
		startingStuff.gameObject.SetActive (false);
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
