using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    public GameObject effectPrefab;
    public Vector3 effectRotation;

    void OnTriggerEnter (Collider other)
    {
        if (!effectPrefab)
        {
            Instantiate(
                effectPrefab,
                this.transform.position,
                Quaternion.Euler(effectRotation)
            );
        }
    }
}