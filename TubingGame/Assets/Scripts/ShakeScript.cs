using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeScript : MonoBehaviour {

	public bool shake = false;
	public GameObject[] shakeArray;
	public GameObject originalPos;
	int i = 0;
	int counter = 0;

	void Start () {
		
	}
	
	void Update () {
		if (shake) {
			DoShake ();
		} //else {
			//gameObject.transform.position = originalPos.transform.position;
		//}
	}

	void DoShake(){
		counter++;
		if (counter > 1) {
			gameObject.transform.position = shakeArray [i].transform.position; 
			i++;
			counter = 0;
			if (i > shakeArray.Length - 1) {
				i = 0;
			}
		}
	}
}
