using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicGra4Player : MonoBehaviour
{
	[SerializeField] DynamicGravity dynamicGravity;
	[SerializeField] HandController rightDevice, leftDevice;
	void Update ()
	{
		if (!rightDevice.IsHandGripping && !leftDevice.IsHandGripping)
		{
			dynamicGravity.enabled = true;
		}
		else
		{
			dynamicGravity.enabled = false;
		}
	}
}