using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinnerScript : MonoBehaviour {

	GameObject manager;
	public Image p1, p2, p3, p4;

	// Use this for initialization
	void Start () {
		manager = GameObject.Find ("GameManager");
		if (manager.GetComponent<GameManagerScript> ().player1Win) {
			p1.gameObject.SetActive (true);
		}
		else if (manager.GetComponent<GameManagerScript> ().player2Win) {
			p2.gameObject.SetActive (true);
		}
		else if (manager.GetComponent<GameManagerScript> ().player3Win) {
			p3.gameObject.SetActive (true);
		}
		else if (manager.GetComponent<GameManagerScript> ().player4Win) {
			p4.gameObject.SetActive (true);
		}
		Destroy (manager);
		Destroy (GameObject.Find ("TitleManager"));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Replay ()
	{
		SceneManager.LoadScene ("Main");
	}

	public void Quit()
	{
		Application.Quit ();
	}
}
