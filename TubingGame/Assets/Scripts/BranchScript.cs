using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BranchScript : MonoBehaviour {

	public bool paired = false;
	GameObject itemParent;
	Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (paired && Input.GetKey(KeyCode.S) && itemParent.GetComponent<MovementScript>().playerId == 0) {
			transform.parent.gameObject.GetComponent<MovementScript> ().hasItem = false;
			StartCoroutine ("Throw");
		}
		if (paired && Input.GetKey(KeyCode.K) && itemParent.GetComponent<MovementScript>().playerId == 1) {
			transform.parent.gameObject.GetComponent<MovementScript> ().hasItem = false;
			StartCoroutine ("Throw");
		}
		if (paired && Input.GetKey(KeyCode.DownArrow) && itemParent.GetComponent<MovementScript>().playerId == 2) {
			transform.parent.gameObject.GetComponent<MovementScript> ().hasItem = false;
			StartCoroutine ("Throw");
		}
		if (paired && Input.GetKey(KeyCode.Keypad5) && itemParent.GetComponent<MovementScript>().playerId == 3) {
			transform.parent.gameObject.GetComponent<MovementScript> ().hasItem = false;
			StartCoroutine ("Throw");
		}
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player" && !paired && !col.gameObject.GetComponent<MovementScript>().hasItem && !col.gameObject.GetComponent<MovementScript>().hasSpare)
		{
			col.gameObject.GetComponent<MovementScript>().hasItem = true;
			paired = true;
			transform.SetParent (col.gameObject.transform);
			//gameObject.transform.position = new Vector3 (0, 0, -10); //I think this was setting the position to the wrong area
			itemParent = transform.parent.gameObject;
		}
	}

	IEnumerator Throw()
	{
		paired = false;
		transform.SetParent (null);
		rb.bodyType = RigidbodyType2D.Dynamic;
		rb.AddForce (Vector2.up * 120.0f);
		yield return new WaitForSeconds (.25f);
		GetComponent<PolygonCollider2D> ().isTrigger = false;
		rb.bodyType = RigidbodyType2D.Kinematic;
		GetComponent<BranchScript> ().enabled = false;
	}
}
