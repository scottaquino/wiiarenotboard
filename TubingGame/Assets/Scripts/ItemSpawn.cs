using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawn : MonoBehaviour {

	List<GameObject> items;
	public List<bool> canSpawn;

	// Use this for initialization
	void Start () {
		items = new List<GameObject> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

	/* canSpawn index guide:
	 * 0 = Tree/Log
	 * 1 = Branch
	 * 2 = Alligator
	 * 3 = Whirlpool
	 * 4 = Spare Tube
	 * 5 = Oar
