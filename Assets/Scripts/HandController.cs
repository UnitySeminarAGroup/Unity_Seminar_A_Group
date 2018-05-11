﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour
{
    public bool IsHandGripping, IsFootGripping, IsWalking;
    public Vector3 GripPosition, FootGripPosition, ControllerVelocity;
    public bool IsTriggered, IsPadTouched;
    [SerializeField] SteamVR_TrackedObject HandDevice, FootDevice;
    [SerializeField] Renderer modelrend;
    [SerializeField] Animator animator;
    [SerializeField] AudioSource audioSource;
    Rigidbody rb;
    float GripTimer;
    SteamVR_Controller.Device device;
    void Start ()
    {
        HandDevice = GetComponent<SteamVR_TrackedObject> ();
        rb = GetComponent<Rigidbody> ();
        device = SteamVR_Controller.Input ((int) HandDevice.index);
    }
    void Update ()
    {
        IsTriggered = device.GetPressDown (SteamVR_Controller.ButtonMask.Trigger);
        IsPadTouched = device.GetPressDown (SteamVR_Controller.ButtonMask.Touchpad) || device.GetPress (SteamVR_Controller.ButtonMask.Touchpad);
        ControllerVelocity = rb.velocity;
        if (device.GetTouchUp (SteamVR_Controller.ButtonMask.Trigger))
        {
            HandRelease (0);
        }
        if (!IsWalking && device.GetPressDown (SteamVR_Controller.ButtonMask.Grip))
        {
            modelrend.material.color = Color.green;
            IsWalking = true;
        }
        if (IsWalking && device.GetPressUp (SteamVR_Controller.ButtonMask.Grip))
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
            animator.SetBool ("Trigger", true);
        }
        if (IsPadTouched)
        {
            Time.timeScale = 10;
        }
        else
        {
            Time.timeScale = 1;
        }
        if (GripTimer > 0)
        {
            GripTimer -= Time.deltaTime;
            modelrend.material.color += new Color (0.01f, 0.01f, 0.01f, 0);
        }
        else if (!IsHandGripping)
        {
            GripTimer = 0;
            modelrend.material.color = Color.white;
        }
    }

    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.tag == "AddPoint")
        {
            int p = other.GetComponent<PointController> ().ScorePoint;
            other.GetComponent<ParticleManager>().InitParticle();
            Debug.Log(other.GetComponent<ParticleManager>());
            FindObjectOfType<UIController> ().score += p;
            Destroy (other.gameObject);
            audioSource.Play ();
        }
    }

    void OnTriggerStay (Collider collider)
    {
        if (!IsHandGripping)
        {
            if (IsTriggered && collider.tag == "GripPoint" && GripTimer <= 0)
            {
                IsHandGripping = true;
                GripPosition = transform.position;
                modelrend.material.color = Color.red;
                animator.SetBool ("Trigger", true);
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
    public void HandRelease (float GripTime)
    {
        IsTriggered = false;
        IsHandGripping = false;
        GripTimer = GripTime;
        animator.SetBool ("Trigger", false);
        modelrend.material.color = Color.black;
    }
    public void HandShake (ushort ShakePower)
    {
        device.TriggerHapticPulse (ShakePower);
    }
}