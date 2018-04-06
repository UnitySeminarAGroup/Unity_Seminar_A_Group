using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rigidbody;
    [SerializeField] HandController RightDevice, LeftDevice;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (RightDevice.IsHandGripping && LeftDevice.IsHandGripping)
        {
            DowbleGrip();
        }
        else if (RightDevice.IsHandGripping || LeftDevice.IsHandGripping)
        {
            if (RightDevice.IsHandGripping)
            {
                SingleGrip(RightDevice);
            }
            else
            {
                SingleGrip(LeftDevice);
            }
        }
        else
        {
            Fall();
        }
    }
    void DowbleGrip()
    {
        rigidbody.useGravity = false;
        Vector3 RightOffset = RightDevice.transform.position - RightDevice.GripPosition;
        Vector3 LeftOffset = RightDevice.transform.position - LeftDevice.GripPosition;
        Vector3 AveOffset = (RightOffset + LeftOffset) / 2;
        rigidbody.position = rigidbody.position + AveOffset;
    }
    void SingleGrip(HandController device)
    {
        rigidbody.useGravity = false;
        Vector3 offset = device.transform.position - device.GripPosition;
        rigidbody.position = rigidbody.position + offset;
    }
    void Fall()
    {
        rigidbody.useGravity = true;
    }
}
