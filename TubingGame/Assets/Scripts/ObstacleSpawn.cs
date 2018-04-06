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
		LoadObstacles ();
		SpawnObstacle ();
	}
	
	void LoadObstacles()
	{
		if(canSpawn[0])
			obstacles.Add(Resources.Load("Rock") as GameObject);
		else if(canSpawn[1])
			obstacles.Add(Resources.Load("Whirlpool") as GameObject);
		else if(canSpawn[2])
			obstacles.Add(Resources.Load("Gator") as GameObject);
		else if(canSpawn[3])
			obstacles.Add(Resources.Load("Log") as GameObject);
	}

	void SpawnObstacle()
	{
		if (obstacles.Count == 4) {
			Instantiate (obstacles [3], transform.position, Quaternion.identity);
			return;
		}

		int temp = Random.Range (0, 100);

		if (temp <= 50) {
			if (temp <= 30 && obstacles.Count >= 2) {
				if (temp <= 20 && obstacles.Count >= 3) {
					Instantiate (obstacles [Random.Range (0, 2)], transform.position, Quaternion.identity);
				} else
					Instantiate (obstacles [Random.Range (0, 1)], transform.position, Quaternion.identity);
			} else
				Instantiate (obstacles [0], transform.position, Quaternion.identity);
		}
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
