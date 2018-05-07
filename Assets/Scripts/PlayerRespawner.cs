using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawner : MonoBehaviour
{
	void Update ()
	{
		if (transform.position.y < -10)
		{
			transform.position = Vector3.zero;
		}
	}
}