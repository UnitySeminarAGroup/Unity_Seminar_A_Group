using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalActionController : MonoBehaviour
{

    [SerializeField] Animator goalAnimator;
    [SerializeField] AudioSource goalSE;
    void OnTriggerEnter(Collider other)
    {
        if (!goalSE.isPlaying)
        {
            goalSE.Play();
            goalAnimator.SetBool("Trigger", true);
        }

    }
}
