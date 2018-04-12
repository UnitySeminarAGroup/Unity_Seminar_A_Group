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
    public int score;
    private float seconds;
    private float oldseconds;
    public GameObject pointLH;
    public GameObject pointRH;

    // Use this for initialization
    void Start () {
        seconds = 120f;
        oldseconds = 120f;

    }
	
	// Update is called once per frame
	void Update () {

        // スコアを更新
      
        int AllScore;
        int scoretestLH;
        int scoretestRH;
        scoretestLH = pointLH.GetComponent<PointControllerLH>().scoreLH;
        scoretestRH = pointRH.GetComponent<PointControllerRH>().scoreRH;
        AllScore = scoretestLH + scoretestRH;
        ScoreLabel.text = "Score:" + AllScore;
        ScoreLabel1.text = "Score:" + AllScore;

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
