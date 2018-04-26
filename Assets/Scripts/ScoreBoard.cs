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
        scoreBoard.text = "ScoreBoard" + "\n"
		+ "1 : " + recentRanking[0] + "\n" 
		+ "2 : " + recentRanking[1] + "\n" 
		+ "3 : " + recentRanking[2] + "\n" 
		+ "4 : " + recentRanking[3] + "\n" 
		+ "5 : " + recentRanking[4] + "\n"
		+ "6 : " + recentRanking[5] + "\n"
		+ "7 : " + recentRanking[6] + "\n"
		+ "8 : " + recentRanking[7] + "\n"
		+ "9 : " + recentRanking[8] + "\n"
		+ "10 : " + recentRanking[3] + "\n";
	}
}
