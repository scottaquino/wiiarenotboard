using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRiver : MonoBehaviour {

	public List<GameObject> riverBank;

	GameObject newChunk;
	Vector3 newPos, oldPos;

	int numChunks;
	float yOffset = 0.0f;

	// Use this for initialization
	void Start () {
		numChunks = riverBank.Count-1;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

/*
 * newChunk = riverBank [Random.Range (0, numChunks)];
 * yOffset = (oldPos.position.y + newChunk.renderer.bounds.size.y) - (newChunk.transform.position.y / 2) + .75f;
 * newPos = new Vector3 (0, yOffset, -10);
 * oldPos = newPos;
 * Instantiate (newChunk, newPos, Quaternion.identity); 
 */