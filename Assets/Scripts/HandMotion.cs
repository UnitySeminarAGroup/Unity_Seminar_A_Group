using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandMotion : MonoBehaviour {
    private Animator animator;
    public GameObject hand;

    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        //手のモーションを切り替える
        bool hand1;
        hand1;=hand.GetComponent<HandController>
    }
}
