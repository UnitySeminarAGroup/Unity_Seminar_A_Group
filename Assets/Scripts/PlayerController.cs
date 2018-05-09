using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody PlayerRigidbody;
    [SerializeField] Transform HMDTransform;
    [SerializeField] HandController RightDevice, LeftDevice;
    [SerializeField] float WalkSpeed;
    Vector3 RightPosCash, LeftPosCash;
    void Start ()
    {
        PlayerRigidbody = GetComponent<Rigidbody> ();
        RightPosCash = RightDevice.transform.position;
        LeftPosCash = LeftDevice.transform.position;
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
            if (RightDevice.IsWalking && LeftDevice.IsWalking)
            {
                Walk ();
            }
        }
        if (Input.GetAxis ("Jump") > 0)
        {
            Time.timeScale = 10;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
    void DowbleGrip ()
    {
        PlayerRigidbody.useGravity = false;
        Vector3 RightOffset = RightDevice.transform.position - RightDevice.GripPosition;
        Vector3 LeftOffset = LeftDevice.transform.position - LeftDevice.GripPosition;
        Vector3 AveOffset = (RightOffset + LeftOffset) / 2;
        PlayerRigidbody.position = Vector3.Lerp (PlayerRigidbody.position, PlayerRigidbody.position - AveOffset, 0.1f);
    }
    void SingleGrip (HandController device)
    {
        PlayerRigidbody.useGravity = false;
        Vector3 offset = device.transform.position - device.GripPosition;
        PlayerRigidbody.position = Vector3.Lerp (PlayerRigidbody.position, PlayerRigidbody.position - offset, 0.1f);
    }
    void Fall ()
    {
        PlayerRigidbody.useGravity = true;
    }
    void Walk ()
    {
        float DifPosRight = (RightPosCash - RightDevice.transform.position).magnitude;
        float DifPosLeft = (LeftPosCash - LeftDevice.transform.position).magnitude;
        float AveVeloY = Mathf.Clamp ((DifPosRight + DifPosLeft) / (2 * Time.deltaTime), 0, 3);
        Vector3 forward = new Vector3 (HMDTransform.forward.x, 0, HMDTransform.forward.z).normalized;
        PlayerRigidbody.velocity = forward * WalkSpeed * AveVeloY;
        RightPosCash = RightDevice.transform.position;
        LeftPosCash = LeftDevice.transform.position;
    }
}