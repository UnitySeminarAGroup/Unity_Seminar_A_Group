using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LimitTimeManager : MonoBehaviour {
    float LimitTime;
    UIController ui;
	// Use this for initialization
	void Start () {
        ui = FindObjectOfType<UIController>();
        LimitTime = ui.seconds;
    }
	
	// Update is called once per frame
	void Update () {
        if (LimitTime < 0.01f)
        {
            SceneManager.LoadScene("Title");
        }
	}
}
