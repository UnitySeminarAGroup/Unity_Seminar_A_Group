using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour
{
    public bool IsHandGripping, IsFootGripping;
    public Vector3 GripPosition, FootGripPosition;
    public bool IsTriggered, IsPadTouched;
    [SerializeField] SteamVR_TrackedObject HandDevice, FootDevice;
    [SerializeField] Renderer modelrend;
    void Start ()
    {
        HandDevice = GetComponent<SteamVR_TrackedObject> ();
    }
    void Update ()
    {
        var device = SteamVR_Controller.Input ((int) HandDevice.index);
        IsTriggered = device.GetPressDown (SteamVR_Controller.ButtonMask.Trigger);
        IsPadTouched = device.GetPressDown (SteamVR_Controller.ButtonMask.Touchpad) || device.GetPress (SteamVR_Controller.ButtonMask.Touchpad);
        if (device.GetTouchUp (SteamVR_Controller.ButtonMask.Trigger))
        {
            IsTriggered = false;
            IsHandGripping = false;
            modelrend.material.color = Color.white;
        }

        if (device.GetTouchUp (SteamVR_Controller.ButtonMask.Touchpad))
        {
            IsPadTouched = false;
            IsFootGripping = false;
        }
        if (IsTriggered)
        {
            modelrend.material.color = Color.blue;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "AddPoint")
        {
            FindObjectOfType<UIController>().score++;
        }
    }

    void OnTriggerStay (Collider collider)
    {
        if (!IsHandGripping)
        {
            if (IsTriggered && collider.tag == "GripPoint")
            {
                IsHandGripping = true;
                GripPosition = transform.position;
                modelrend.material.color = Color.red;
            }
        }
        if (!IsFootGripping)
        {
            if (IsPadTouched && collider.tag == "GripPoint")
            {
                IsFootGripping = true;
                //FootGripPosition = FootDevice.transform.position;
            }
        }
    }
}