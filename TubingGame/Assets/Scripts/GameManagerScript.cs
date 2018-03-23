using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour {

	int playerCount;
	public GameObject player2;


	// Use this for initialization
	void Start () {
		playerCount = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.RightBracket) && playerCount < 1)
		{
			playerCount++;
		}
		if (Input.GetKey (KeyCode.LeftBracket) && playerCount > 0) 
		{
			playerCount--;
		}
		if(Input.GetKey(KeyCode.KeypadEnter))
		{
			if(playerCount == 1 && player2)
			{
				player2.SetActive (true);
			}
		}
	}


}
