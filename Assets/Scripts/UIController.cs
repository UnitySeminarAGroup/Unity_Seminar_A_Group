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
    public float settingSeconds;
    private float oldseconds;
    public AudioSource countDown;
    public AudioSource timeUp;
    
    

    // Use this for initialization
    void Start () {
        seconds = settingSeconds;
        oldseconds = settingSeconds;
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
                LimitTimeLabel.text = "Limit : " + Mathf.Floor(seconds) + "s";
            }
            oldseconds = seconds;
            if (5f < seconds && seconds < 11f)
            {
                if(!countDown.isPlaying){
                countDown.Play();

                }
            }else if(seconds < 1f){
                if(!timeUp.isPlaying){
                    timeUp.Play();
                }
            }
        }else{
            seconds = 0f;
        }
        
	}

}
