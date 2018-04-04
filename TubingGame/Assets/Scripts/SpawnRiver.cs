using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRiver : MonoBehaviour {

	//Sprite X = 4000
	//Sprite Y = 8000
	//Old Sprite X = 1920
	//Old Sprite Y = 1080

	public List<GameObject> riverBank;

	GameObject newChunk;
	Vector3 newPos;

	int numChunks;

	// Use this for initialization
	void Start () {
		numChunks = riverBank.Count-1;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player") {
			newChunk = riverBank [Random.Range (0, numChunks)];
			newPos = new Vector3 (transform.position.x + 1.0f, transform.position.y - newChunk.GetComponent<SpriteRenderer> ().bounds.size.y, -10);
			Instantiate (newChunk, newPos, Quaternion.identity);
		}
	}
}