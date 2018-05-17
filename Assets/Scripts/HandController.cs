using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour
{
    public bool IsHandGripping, IsFootGripping, IsWalking;
    public Vector3 GripPosition, FootGripPosition, ControllerVelocity;
    public bool IsTriggering, IsPadTouched;
    [SerializeField] SteamVR_TrackedObject HandDevice, FootDevice;
    [SerializeField] Renderer modelrend;
    [SerializeField] Animator animator;
    [SerializeField] AudioSource audioSource;
    Rigidbody rb;
    float GripTimer, RecoverColor;
    SteamVR_Controller.Device device;
    void Start()
    {
        HandDevice = GetComponent<SteamVR_TrackedObject>();
        rb = GetComponent<Rigidbody>();
        device = SteamVR_Controller.Input((int)HandDevice.index);
    }
    void Update()
    {
        IsTriggering = device.GetPress(SteamVR_Controller.ButtonMask.Trigger);
        IsPadTouched = device.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad) || device.GetPress(SteamVR_Controller.ButtonMask.Touchpad);
        ControllerVelocity = rb.velocity;
        if (device.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger) && GripTimer <= 0)
        {
            HandRelease(0);
        }
        if (!IsWalking && device.GetPressDown(SteamVR_Controller.ButtonMask.Grip))
        {
            modelrend.material.color = Color.green;
            IsWalking = true;
        }
        if (IsWalking && device.GetPressUp(SteamVR_Controller.ButtonMask.Grip))
        {
            IsWalking = false;
            modelrend.material.color = Color.white;
        }
        if (device.GetTouchUp(SteamVR_Controller.ButtonMask.Touchpad))
        {
            IsPadTouched = false;
            IsFootGripping = false;
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
            var colorOffset = RecoverColor * Time.deltaTime;
            modelrend.material.color += new Color(colorOffset, colorOffset, colorOffset, 0);
        }
        else
        {
            if (!IsHandGripping && !IsWalking)
            {
                GripTimer = 0;
                modelrend.material.color = Color.white;
            }
        }
        if (IsTriggering && !IsHandGripping && GripTimer == 0)
        {
            modelrend.material.color = Color.blue;
            animator.SetBool("Trigger", true);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "AddPoint")
        {
            int p = other.GetComponent<PointController>().ScorePoint;
            other.GetComponent<ParticleManager>().InitParticle();
            Debug.Log(other.GetComponent<ParticleManager>());
            var UIlist = FindObjectsOfType<UIController>();
            foreach(UIController u in UIlist)
            {
                u.score += p;
            }
            Destroy(other.gameObject);
            audioSource.Play();
        }
    }

    void OnTriggerStay(Collider collider)
    {
        if (!IsHandGripping)
        {
            if (IsTriggering && collider.tag == "GripPoint" && GripTimer <= 0)
            {
                IsHandGripping = true;
                GripPosition = transform.position;
                modelrend.material.color = Color.red;
                animator.SetBool("Trigger", true);
            }
        }
        if (!IsFootGripping)
        {
            if (IsPadTouched && collider.tag == "GripPoint")
            {
                IsFootGripping = true;
            }
        }
    }
    public void HandRelease(float RecoverTime)
    {
        IsTriggering = false;
        IsHandGripping = false;
        GripTimer = RecoverTime;
        RecoverColor = 1 / RecoverTime;
        animator.SetBool("Trigger", false);
        modelrend.material.color = Color.black;
        if (RecoverColor == 0)
        {
            modelrend.material.color = Color.white;
        }
    }
    public void HandShake(ushort ShakePower)
    {
        device.TriggerHapticPulse(ShakePower);
    }
}