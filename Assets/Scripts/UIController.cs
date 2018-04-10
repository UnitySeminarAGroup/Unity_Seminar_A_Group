using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {
    public Text ScoreLabel;
    public Text ScoreLabel1;
    public Text LimitTimeLabel;
    public Text LimitTimeLabel1;
    public Text DistanceLabel;

    private float seconds;
    private float oldseconds;
    public GameObject pointTest;

	// Use this for initialization
	void Start () {
        seconds = 120f;
        oldseconds = 120f;

    }
	
	// Update is called once per frame
	void Update () {

        // スコアを更新
      
        int bscore;
        bscore = pointTest.GetComponent<PointController>().score;
        ScoreLabel.text = "Score:" + bscore;
        ScoreLabel1.text = "Score:" + bscore;

        // 残り時間を更新
        if (seconds >= 0f)
        {
            seconds -= Time.deltaTime;
            if (seconds != oldseconds)
            {
                LimitTimeLabel.text = "LimitTime : " + Mathf.Ceil(seconds) + "s";
                LimitTimeLabel1.text = "LimitTime : " + Mathf.Ceil(seconds) + "s";
            }
            oldseconds = seconds;
        }else{
            seconds = 0f;
        }
        
        // 頭と両足の距離を更新
        // int 

	}

}
