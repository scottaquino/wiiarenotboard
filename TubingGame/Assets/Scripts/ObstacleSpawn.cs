using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawn : MonoBehaviour {

	List<GameObject> obstacles;
	[Header("Rock, Whirlpool, Gator, Log Spawn")]
	public List<bool> canSpawn;

	float time;
	float obstacleChance = .2f;
	float itemChance = .2f;
	int numZones = 0;
	int numObsSpawned = 0;
	int numItemsSpawned = 0;
	float obsToSpawn;
	float itemsToSpawn;

	// Use this for initialization
	void Start () {
		numZones = transform.parent.childCount - 1;
		numObsSpawned = transform.parent.gameObject.GetComponent<SpawnManagement> ().numObstacles;
		numItemsSpawned = transform.parent.gameObject.GetComponent<SpawnManagement> ().numItems;
		obstacles = new List<GameObject> ();
		AdjustChance ();
		LoadObstacles ();
		SpawnObstacle ();
	}

	void AdjustChance ()
	{
		time = GameObject.Find ("GameManager").GetComponent<TimeManagement> ().timePassed;
		obstacleChance += (time % 15.0f) * 4.0f;
		itemChance += (time % 15.0f) * 2.0f;
		obsToSpawn = (float)numZones * obstacleChance;
		itemsToSpawn = (float)numZones * itemChance;
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

		if (temp <= 50 && numObsSpawned < obsToSpawn) {
			if (temp <= 30 && obstacles.Count >= 4) {
				if (temp <= 20 && obstacles.Count >= 5) {
					Instantiate (obstacles [Random.Range (2, 4)], transform.position, Quaternion.identity);
					transform.parent.gameObject.GetComponent<SpawnManagement> ().numObstacles++;
				} else {
					Instantiate (obstacles [Random.Range (2, 3)], transform.position, Quaternion.identity);
					transform.parent.gameObject.GetComponent<SpawnManagement> ().numObstacles++;
				}
			} else {
				Instantiate (obstacles [2], transform.position, Quaternion.identity);
				transform.parent.gameObject.GetComponent<SpawnManagement> ().numObstacles++;
			}
		} else if (temp > 50 && temp < 90 && numItemsSpawned < itemsToSpawn) {
			Instantiate (obstacles [0], transform.position, Quaternion.identity);
			transform.parent.gameObject.GetComponent<SpawnManagement> ().numItems++;
		} else if (numItemsSpawned < itemsToSpawn) {
			Instantiate (obstacles [1], transform.position, Quaternion.identity);
			transform.parent.gameObject.GetComponent<SpawnManagement> ().numItems++;
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
