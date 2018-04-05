using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[SerializeField] HandController RightDevice,LeftDevice;
	void Start ()
	{

	}
	void Update ()
	{
		if(RightDevice.IsHandGripping && LeftDevice.IsHandGripping)
		{
			DowbleGrip();
		}
		else if(RightDevice.IsHandGripping || LeftDevice.IsHandGripping)
		{
			SingleGrip();
		}
		else
		{
			Fall();
		}
	}
	void DowbleGrip()
	{

	}
	void SingleGrip()
	{

	}
	void Fall()
	{

	}
}
