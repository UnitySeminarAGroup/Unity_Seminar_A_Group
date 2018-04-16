﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour
{
    public bool IsHandGripping, IsFootGripping,IsWalking;
    public Vector3 GripPosition, FootGripPosition,ControllerVelocity;
    public bool IsTriggered, IsPadTouched;
    [SerializeField] SteamVR_TrackedObject HandDevice, FootDevice;
    [SerializeField] Renderer modelrend;
    Rigidbody rb;
    void Start ()
    {
        HandDevice = GetComponent<SteamVR_TrackedObject> ();
        rb = GetComponent<Rigidbody>();
    }
    void Update ()
    {
        var device = SteamVR_Controller.Input ((int) HandDevice.index);
        IsTriggered = device.GetPressDown (SteamVR_Controller.ButtonMask.Trigger);
        IsPadTouched = device.GetPressDown (SteamVR_Controller.ButtonMask.Touchpad) || device.GetPress (SteamVR_Controller.ButtonMask.Touchpad);
        ControllerVelocity = rb.velocity;
        if (device.GetTouchUp (SteamVR_Controller.ButtonMask.Trigger))
        {
            IsTriggered = false;
            IsHandGripping = false;
            modelrend.material.color = Color.white;
        }
        if(device.GetPressDown(SteamVR_Controller.ButtonMask.Grip))
        {
            Ray ray = new Ray(transform.position,transform.forward);
            RaycastHit hit;
            if(Physics.Raycast(ray,out hit))
            {
                modelrend.material.color = Color.green;
                IsWalking = true;
            }
        }
        if (device.GetPressUp(SteamVR_Controller.ButtonMask.Grip))
        {
            IsWalking = false;
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
        if(other.gameObject.tag == "AddPoint")
        {
            int p = other.GetComponent<PointController>().ScorePoint;
            FindObjectOfType<UIController>().score += p;
            Destroy(other.gameObject);
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