using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhirlpoolScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player") {
			StartCoroutine ("PushAway");
		}
	}

	private IEnumerator PushAway()
	{
		yield return new WaitForSeconds (.5f);
		GetComponent<PointEffector2D> ().forceMagnitude = 150.0f;
		yield return new WaitForSeconds (2.0f);
		GetComponent<PointEffector2D> ().forceMagnitude = -25.0f;
	}
}
