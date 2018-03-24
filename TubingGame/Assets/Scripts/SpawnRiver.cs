using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRiver : MonoBehaviour {

	public GameObject riverBank;
	Vector3 newPos;

	// Use this for initialization
	void Start () {
		StartCoroutine ("Spawn");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator Spawn()
	{
		yield return new WaitForSeconds (1.0f);
		while (true) {
			newPos = new Vector3 (Random.Range (-3.0f, 3.0f), transform.position.y, transform.position.z);
			Instantiate(riverBank, newPos, Quaternion.identity);
			yield return new WaitForSeconds (.5f);
		}
	}
}
