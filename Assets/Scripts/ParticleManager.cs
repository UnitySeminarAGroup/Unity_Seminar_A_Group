using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    public GameObject effectPrefab;
    public Vector3 effectRotation;

    public void InitParticle ()
    {
        if (effectPrefab)
        {
            GameObject obj =  Instantiate(
                effectPrefab,
                this.transform.position,
                Quaternion.Euler(effectRotation)
            );
            Debug.Log(obj.transform.parent);
            obj.transform.parent = null;
        }
    }
}