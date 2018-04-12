using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour {

	public bool paired = false;
	GameObject itemParent;
	Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (paired && Input.GetKeyDown(KeyCode.LeftShift) && itemParent.GetComponent<MovementScript>().playerId == 0) {
			StartCoroutine ("Throw");
		}
		if (paired && Input.GetKeyDown(KeyCode.RightShift) && itemParent.GetComponent<MovementScript>().playerId == 1) {
			StartCoroutine ("Throw");
		}
		if (paired && Input.GetKeyDown(KeyCode.Space) && itemParent.GetComponent<MovementScript>().playerId == 2) {
			StartCoroutine ("Throw");
		}
		if (paired && Input.GetKeyDown(KeyCode.RightControl) && itemParent.GetComponent<MovementScript>().playerId == 3) {
			StartCoroutine ("Throw");
		}
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player" && !paired) {
			paired = true;
			transform.SetParent (col.gameObject.transform);
			gameObject.transform.position = new Vector3 (0, 0, -10);
			itemParent = transform.parent.gameObject;
		}
	}

	IEnumerator Throw()
	{
		transform.SetParent (null);
		rb.bodyType = RigidbodyType2D.Dynamic;
		rb.AddForce (Vector2.up * 100.0f);
		yield return new WaitForSeconds (.25f);
		rb.bodyType = RigidbodyType2D.Kinematic;
		GetComponent<ItemScript> ().enabled = false;
	}
}
