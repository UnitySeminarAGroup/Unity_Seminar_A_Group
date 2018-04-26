using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {
    public Text ScoreLabel;
    public Text LimitTimeLabel;
    public Text DistanceLabel;
    public int score;
    public float seconds;
    private float oldseconds;
    
    

    // Use this for initialization
    void Start () {
        seconds = 120f;
        oldseconds = 120f;
        score = 0;

    }
	
	// Update is called once per frame
	void Update () {

        // スコアを更新
      
        ScoreLabel.text = "Score : " + score;

        // 残り時間を更新
        if (seconds >= 0f)
        {
            seconds -= Time.deltaTime;
            if (seconds != oldseconds)
            {
                LimitTimeLabel.text = "Limit : " + Mathf.Ceil(seconds) + "s";
            }
            oldseconds = seconds;
        }else{
            seconds = 0f;
        }
        

	}

}
