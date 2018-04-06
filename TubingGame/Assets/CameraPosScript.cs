using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosScript : MonoBehaviour {

	public GameObject camera;

	// Use this for initialization
	void Start () {
		camera = GameObject.Find ("MainCamera");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player" && col.gameObject.GetComponent<MovementScript>().first) {
			camera.GetComponent<CameraControl> ().target = gameObject.GetComponentInParent<ChunkCameraScript>().cameraPositions[gameObject.GetComponentInParent<ChunkCameraScript>().currentCameraPos];
			if(gameObject.GetComponentInParent<ChunkCameraScript>().currentCameraPos < 6)
			{
				gameObject.GetComponentInParent<ChunkCameraScript>().currentCameraPos++;
				Debug.Log (gameObject.GetComponentInParent<ChunkCameraScript>().currentCameraPos);
			}
			Debug.Log ("HERE");
		}
	}

}
