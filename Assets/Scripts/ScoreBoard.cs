using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour {
    public Text scoreBoard;
    int[] recentRanking = new int[10]; 

	// Use this for initialization
	void Start () {
        recentRanking = GetComponent<HighScoreManager>().ranking;
	}
	
	// Update is called once per frame
	void Update () {
		// スコアボードを更新
        scoreBoard.text="1 : " + recentRanking[0];
	}
}
