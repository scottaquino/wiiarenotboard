using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRiver : MonoBehaviour {

	public List<GameObject> riverBank;

	GameObject newChunk;
	Vector3 newPos, oldPos;

	int numChunks;
	float yOffset = 0.0f;
	float spriteBounds = 0.0f;

	// Use this for initialization
	void Start () {
		numChunks = riverBank.Count-1;
		oldPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerExit2D(Collider2D col)
	{
		if (col.gameObject.tag == "River") {
			newChunk = riverBank [Random.Range (0, numChunks)];
			spriteBounds = newChunk.GetComponent<SpriteRenderer> ().bounds.size.y;
			yOffset = col.gameObject.transform.position.y - spriteBounds;
			newPos = new Vector3 (0, yOffset, -10);
			Instantiate (newChunk, newPos, Quaternion.identity);
		}
	}
}