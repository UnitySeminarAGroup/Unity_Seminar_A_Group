using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroyEffect : MonoBehaviour {
	ParticleSystem pointParticle;

	void Start () 
	{
		pointParticle = GetComponent<ParticleSystem>();
	}

	void Update () 
	{
		if(!pointParticle.isPlaying)
		{
			Destroy(gameObject);
            Debug.Log("Auto Destroyed");
		}
	}
}
