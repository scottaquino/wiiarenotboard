using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawn : MonoBehaviour {

	List<GameObject> obstacles;
	[Header("Rock, Whirlpool, Gator, Log Spawn")]
	public List<bool> canSpawn;

	// Use this for initialization
	void Start () {
		obstacles = new List<GameObject> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

/* canSpawn index guide:
 //For Water
 * 0 = Rock //50% chance spawn
 * 1 = Whirlpool // 30% chance spawn
 * 2 = Gator // 20% chance spawn

 //For Land 
 * 3 = Log Spawn //100% chance spawn
 */
