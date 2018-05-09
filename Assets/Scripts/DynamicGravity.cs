using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicGravity : MonoBehaviour
{
	[SerializeField] Rigidbody rb;
	[SerializeField] Vector3 gravity;
	void FixedUpdate ()
	{
		rb.useGravity = false;
		rb.AddForce (gravity, ForceMode.Acceleration);
	}
}