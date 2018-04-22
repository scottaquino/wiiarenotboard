using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManagement : MonoBehaviour {

	public float timePassed = 0.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		timePassed += Time.deltaTime;
	}
}
