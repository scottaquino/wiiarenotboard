using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicatorScript : MonoBehaviour
{
	//Locate GameObjects
	public GameObject target;
	public GameObject minDistance;
	public GameObject cam;
	private SpriteRenderer sR;
	private Color sRC;

	//Locations
	public float initialIndicatorOffset;
	private Vector2 curPos;
	private bool coroutineStarted = false;
	public float destroyTime = 1.5f;

	//Blinking
	private float blinkSpeed = 2;
	public float blinkTime = 30;
	private float blinkTimeRef;
	private bool blinkAway = true;

	private void Start()
	{
		//Get spriterenderer and color component
		sR = this.GetComponent<SpriteRenderer>();
		sRC = sR.color;

		//Set target of indicator, find min distance
		target = FindParentWithTag(this.gameObject, "Obstacle");
		minDistance = FindMinDistance(this.gameObject, "Min_Distance");

		//Find camera, set position of indicator
		cam = GameObject.Find("MainCamera");
		StartPosition();

		//Set reference to blinkTime
		blinkTimeRef = blinkTime;
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

	private void FixedUpdate()
	{
		SetPosition();
		Blinking();
	}

	//Moves indicator
	private void SetPosition()
	{
		curPos = this.transform.position;

		//Starts destroy script for indicator
		if (curPos.y <= minDistance.transform.position.y)
		{
			if (!coroutineStarted)
			{
				coroutineStarted = true;
				StartCoroutine("DestroyIndicator");
				Debug.Log("IT HAS STARTED");
			}

		}

		//Moves indicator with bottom of camera
		else if (curPos.y >= cam.transform.position.y - 4.8f && curPos.y > minDistance.transform.position.y)
		{
			Vector2 newPos = new Vector2();
			newPos.x = this.transform.position.x;
			newPos.y = cam.transform.position.y - 4.8f;

			this.transform.position = newPos;
			curPos = newPos;
		}
	}

	private void Blinking()
	{
		if (blinkAway)
		{
			blinkTime -= blinkSpeed;
			sRC = new Color(1f, 1f, 1f, (blinkTime / blinkTimeRef));
			sR.color = sRC;

			if (blinkTime <= 0) //Check for switch
			{
				blinkAway = !blinkAway;
			}
		}
		else if (!blinkAway)
		{
			blinkTime += blinkSpeed;
			sRC = new Color(1f, 1f, 1f, (blinkTime / blinkTimeRef));
			sR.color = sRC;

			if (blinkTime >= blinkTimeRef) //Check for switch
			{
				blinkAway = !blinkAway;
			}
		}

	}

	IEnumerator DestroyIndicator()
	{
		yield return new WaitForSeconds(destroyTime);
		Destroy(this.gameObject);
	}
}
