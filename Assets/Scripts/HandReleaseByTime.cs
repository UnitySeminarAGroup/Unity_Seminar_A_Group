using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandReleaseByTime : MonoBehaviour
{
	[SerializeField] HandController handcontroller;
    [SerializeField] float ReleaseTime,ResurrectionTime;
    float Timer;
    bool HasGripped;
	void Update ()
	{
        if (handcontroller.IsHandGripping)
        {
            if (!HasGripped)
            {
                Timer = ReleaseTime;
                HasGripped = true;
            }
            Timer -= Time.deltaTime;
            if (Timer < 0)
            {
                handcontroller.HandRelease(ResurrectionTime);
                HasGripped = false;
            }
        }
        else
        {
            HasGripped = false;
        }
	}
}