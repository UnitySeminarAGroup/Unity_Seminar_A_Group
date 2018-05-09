using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandReleaseByTime : MonoBehaviour
{
    [SerializeField] HandController handcontroller;
    [SerializeField] float ReleaseTime, ResurrectionTime, ShakeSize, ShakePower;
    [SerializeField] Transform ModelTransform;
    [SerializeField] AnimationCurve TimeCurve;
    float Timer;
    bool HasGripped;
    Vector3 ModelLocalPosition;
    void Start ()
    {
        ModelLocalPosition = ModelTransform.localPosition;
    }
    void Update ()
    {
        if (handcontroller.IsHandGripping)
        {
            if (!HasGripped)
            {
                Timer = 0;
                HasGripped = true;
            }
            Timer += Time.deltaTime;
            ModelTransform.localPosition = ModelLocalPosition + (new Vector3 (Random.value, Random.value, Random.value).normalized * ShakeSize * TimeCurve.Evaluate (Timer));
            if (TimeCurve.Evaluate (Timer) > 0)
            {
                handcontroller.HandShake ((ushort) (TimeCurve.Evaluate (Timer) * ShakePower));
            }
            if (Timer > ReleaseTime)
            {
                handcontroller.HandRelease (ResurrectionTime);
                HasGripped = false;
            }
        }
        else
        {
            HasGripped = false;
        }
    }
}