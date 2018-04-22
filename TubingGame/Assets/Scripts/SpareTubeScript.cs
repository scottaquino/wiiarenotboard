using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpareTubeScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Player" && !col.gameObject.GetComponent<MovementScript>().hasItem) {
			col.gameObject.GetComponent<MovementScript> ().hasItem = true;
			col.gameObject.GetComponent<MovementScript> ().hasSpare = true;
			col.gameObject.GetComponent<MovementScript> ().spareTube.gameObject.SetActive (true);
			Destroy (gameObject);
		}
	}
}
