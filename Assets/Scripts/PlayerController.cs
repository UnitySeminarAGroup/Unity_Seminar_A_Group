using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rigidbody;
    [SerializeField] HandController RightDevice, LeftDevice;
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
}