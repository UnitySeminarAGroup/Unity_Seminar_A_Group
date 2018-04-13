using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rigidbody;
    [SerializeField] Transform HMDTransform;
    [SerializeField] HandController RightDevice, LeftDevice;
    [SerializeField] float WalkMinLimit,WalkSpeed;
    void Start ()
    {
        rigidbody = GetComponent<Rigidbody> ();
    }
    void Update ()
    {
        if (RightDevice.IsHandGripping && LeftDevice.IsHandGripping)
        {
            DowbleGrip ();
        }
        else if (RightDevice.IsHandGripping || LeftDevice.IsHandGripping)
        {
            if (RightDevice.IsHandGripping)
            {
                SingleGrip (RightDevice);
            }
            else
            {
                SingleGrip (LeftDevice);
            }
        }
        else
        {
            Fall ();
        }
        if(!(RightDevice.IsHandGripping || LeftDevice.IsHandGripping) && (RightDevice.IsWalking && LeftDevice.IsWalking))
        {
            Walk();
        }
    }
    void DowbleGrip ()
    {
        rigidbody.useGravity = false;
        Vector3 RightOffset = RightDevice.transform.position - RightDevice.GripPosition;
        Vector3 LeftOffset = LeftDevice.transform.position - LeftDevice.GripPosition;
        Vector3 AveOffset = (RightOffset + LeftOffset) / 2;
        rigidbody.position = Vector3.Lerp (rigidbody.position, rigidbody.position - AveOffset, 0.1f);
    }
    void SingleGrip (HandController device)
    {
        rigidbody.useGravity = false;
        Vector3 offset = device.transform.position - device.GripPosition;
        rigidbody.position = Vector3.Lerp (rigidbody.position, rigidbody.position - offset, 0.1f);
    }
    void Fall ()
    {
        rigidbody.useGravity = true;
    }
    void Walk()
    {
        float RVeloY = RightDevice.transform.InverseTransformDirection(RightDevice.ControllerVelocity).y;
        float LVeloY = LeftDevice.transform.InverseTransformDirection(LeftDevice.ControllerVelocity).y;
        float AveVeloY = (Mathf.Abs(RVeloY) + Mathf.Abs(LVeloY))/2;
        if(Mathf.Abs(RVeloY) > WalkMinLimit && Mathf.Abs(LVeloY) > WalkMinLimit && (RVeloY*LVeloY)<0)
        {
            rb.velocity = HMDTransform.forward * WalkSpeed * AveVeloY;
        }
    }
}