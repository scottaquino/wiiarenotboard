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
	bool spawned = false;
	public GameObject camera;

	int numChunks;

	// Use this for initialization
	void Start () {
		numChunks = riverBank.Count;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player" && !spawned) {
			newChunk = riverBank [Random.Range(0, numChunks)];
			if(newChunk == riverBank[0])
				newPos = new Vector3 (transform.position.x + 13.15f, transform.position.y - (newChunk.GetComponent<SpriteRenderer> ().bounds.size.y / 2) - .3f, -1);
			else if(newChunk == riverBank[1])
				newPos = new Vector3 (transform.position.x - 10.0f, transform.position.y - (newChunk.GetComponent<SpriteRenderer> ().bounds.size.y / 2) - .3f, -1);
			Instantiate (newChunk, newPos, Quaternion.identity);
			GetComponent<SpawnRiver> ().enabled = false;
			spawned = true;
		}
	}
}