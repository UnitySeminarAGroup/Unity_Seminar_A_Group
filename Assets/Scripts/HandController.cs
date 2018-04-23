using System.Collections;
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
    void Start ()
    {
        HandDevice = GetComponent<SteamVR_TrackedObject> ();
        rb = GetComponent<Rigidbody> ();
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
            animator.SetBool("Trigger", false);
            modelrend.material.color = Color.white;
        }
        if (!IsWalking &&device.GetPressDown (SteamVR_Controller.ButtonMask.Grip))
        {
            modelrend.material.color = Color.green;
            IsWalking = true;
        }
        if (IsWalking &&device.GetPressUp (SteamVR_Controller.ButtonMask.Grip))
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
            animator.SetBool("Trigger", true);
        }
        if (IsPadTouched)
        {
            Time.timeScale = 10;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.tag == "AddPoint")
        {
            int p = other.GetComponent<PointController> ().ScorePoint;
            FindObjectOfType<UIController> ().score += p;
            Destroy (other.gameObject);
            audioSource.Play();
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
                animator.SetBool("Trigger",true);
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