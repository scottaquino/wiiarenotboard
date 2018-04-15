using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicatorScript : MonoBehaviour
{
	//Locate GameObjects
	public GameObject target;
	public GameObject minDistance;
	public GameObject cam;

	//Locations
	public float initialIndicatorOffset;
	private Vector2 curPos;
	private bool coroutineStarted = false;

	//Blinking
	public float blinkSpeed;

	private void Start()
	{
		target = FindParentWithTag(this.gameObject, "Obstacle");
		minDistance = FindMinDistance(this.gameObject, "Min_Distance");
		cam = GameObject.Find("MainCamera");
		StartPosition();
	}

	//Returns Obstacle
	public GameObject FindParentWithTag(GameObject indicator, string tag)
	{
		Transform t = indicator.transform;
		while (t.parent != null)
		{
			if (t.parent.tag == tag)
			{
				return t.parent.gameObject;
			}
			t = t.parent.transform;
		}
		return null; //Could not find parent with tag
		//Debug.Log("Cannot find object with tag");
	}

	//Returns minimum distance indicator can be from obstacle
	public GameObject FindMinDistance(GameObject indicator, string minD)
	{
		Transform t = indicator.transform.parent;
		GameObject minDistance = t.Find(minD).gameObject;
		return minDistance;
	}

	//Transform start position of indicator to X of obstacle and Y + 50 of camera
	public void StartPosition()
	{
		Vector2 thisPos = new Vector2();
		thisPos.x = target.transform.position.x; //Get obstacle's X
		thisPos.y = cam.transform.position.y + initialIndicatorOffset; //Get beneath camera

		//Set indicator's position
		this.transform.position = thisPos;
		curPos = thisPos;
	}

	private void Update()
	{
		SetPosition();
		Blinking();
	}

	private void SetPosition()
	{
		curPos = this.transform.position;
		if (curPos.y <= minDistance.transform.position.y)
		{
			if (!coroutineStarted)
			{
				coroutineStarted = true;
				StartCoroutine("DestroyIndicator");
				Debug.Log("IT HAS STARTED");
			}

		}
		else if (curPos.y >= cam.transform.position.y - 4.5f && curPos.y > minDistance.transform.position.y)
		{
			Vector2 newPos = new Vector2();
			newPos.x = this.transform.position.x;
			newPos.y = cam.transform.position.y - 4.5f;

			this.transform.position = newPos;
			curPos = newPos;
		}
	}

	private void Blinking()
	{
		//null
	}

	IEnumerator DestroyIndicator()
	{
		yield return new WaitForSeconds(1.5f);
		Destroy(this.gameObject);
	}
}
