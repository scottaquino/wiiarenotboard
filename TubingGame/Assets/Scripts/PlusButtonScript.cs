using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlusButtonScript : MonoBehaviour {

	public GameObject manager;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		manager.GetComponent<TitleManagerScript> ().AddPlayers ();
	}
}
