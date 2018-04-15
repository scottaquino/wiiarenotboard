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
		obstacles.Add (Resources.Load ("Branch") as GameObject);
		obstacles.Add (Resources.Load ("SpareTube") as GameObject);
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
		for (int i = 0; i < obstacles.Count; i++) {
			if(obstacles[i] == Resources.Load("Log") as GameObject){
				Instantiate (obstacles [i], transform.position, Quaternion.identity);
				return;
			}
		}

		int temp = Random.Range (0, 100);

		if (temp <= 50) {
			if (temp <= 30 && obstacles.Count >= 4) {
				if (temp <= 20 && obstacles.Count >= 5) {
					Instantiate (obstacles [Random.Range (2, 4)], transform.position, Quaternion.identity);
				} else
					Instantiate (obstacles [Random.Range (2, 3)], transform.position, Quaternion.identity);
			} else
				Instantiate (obstacles [2], transform.position, Quaternion.identity);
		} else if(temp > 50 && temp < 90)
			Instantiate (obstacles [0], transform.position, Quaternion.identity);
		else
			Instantiate (obstacles [1], transform.position, Quaternion.identity);
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
