using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicatorTrigger : MonoBehaviour
{
	public GameObject indicator;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Obstacle_Trigger")
		{
			GameObject colParent = collision.transform.parent.gameObject;
			GameObject childObject = Instantiate(indicator) as GameObject;
			childObject.transform.parent = colParent.transform;
		}
	}
}
