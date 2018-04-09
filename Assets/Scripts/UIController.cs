using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {
    public Text ScoreLabel;
    public Text LimitTimeLabel;
    public Text DistanceLabel;

    private float seconds;
    private float oldseconds;

	// Use this for initialization
	void Start () {
        seconds = 120f;
        oldseconds = 120f;
    }
	
	// Update is called once per frame
	void Update () {

        // スコアを更新
        // int score =;
        // ScoreLabel.txt = "Score;" + score;


        // 残り時間を更新
        if (seconds >= 0f)
        {
            seconds -= Time.deltaTime;
            if (seconds != oldseconds)
            {
                LimitTimeLabel.text = "残り時間:" + Mathf.Ceil(seconds) + "秒";
            }
            oldseconds = seconds;
        }else{
            seconds = 0f;
        }
        
        // 頭と両足の距離を更新
        int 

	}
}
