using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RapidsSpawn : MonoBehaviour {

	// Use this for initialization
	void Start () {
		int temp = Random.Range (0, 100);
		if (temp <= 50) {
			GetComponent<SpriteRenderer> ().enabled = false;
			GetComponent<PolygonCollider2D> ().enabled = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
