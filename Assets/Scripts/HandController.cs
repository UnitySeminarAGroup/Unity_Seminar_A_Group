using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour
{
	public bool IsHandGripping, IsFootGripping;
	public Vector3 GripPosition,FootGripPosition;
	bool IsTriggered, IsPadTouched;
	[SerializeField] SteamVR_TrackedObject HandDevice,FootDevice;
	void Start ()
	{
		HandDevice = GetComponent<SteamVR_TrackedObject> ();
	}
	void Update ()
	{
		var device = SteamVR_Controller.Input ((int) HandDevice.index);
		IsTriggered = device.GetTouchDown (SteamVR_Controller.ButtonMask.Trigger) || device.GetPressDown (SteamVR_Controller.ButtonMask.Trigger);
		IsPadTouched = device.GetPressDown (SteamVR_Controller.ButtonMask.Touchpad) || device.GetPress (SteamVR_Controller.ButtonMask.Touchpad);
		if (device.GetTouchUp (SteamVR_Controller.ButtonMask.Trigger))
		{
			IsTriggered = false;
			IsHandGripping = false;
		}
		if (device.GetTouchUp (SteamVR_Controller.ButtonMask.Touchpad))
		{
			IsPadTouched = false;
			IsFootGripping = false;
		}
	}
	void OnTriggerStay ()
	{
		if (!IsHandGripping)
		{
			if (IsTriggered)
			{
				IsHandGripping = true;
				GripPosition = transform.position;
			}
		}
		if (!IsFootGripping)
		{
			if (IsPadTouched)
			{
				IsFootGripping = true;
				FootGripPosition = FootDevice.transform.position;
			}
		}
	}
}