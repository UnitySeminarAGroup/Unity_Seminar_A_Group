using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour {
    public Text scoreBoard;
    public Text scoreBoard2;
    public Text scoreBoard3;
    int[] recentRanking = new int[10];
    int[] recentRanking2 = new int[10];
    int[] recentRanking3 = new int[10];

    // Use this for initialization
    void Start () {
        recentRanking = GetComponent<HighScoreManager>().ranking;
        recentRanking2 = GetComponent<Stage2_HighScoreManager>().ranking2;
        recentRanking3 = GetComponent<Stage3_HighScoreManager>().ranking3;
    }
	
	// Update is called once per frame
	void Update () {
		// スコアボードを更新
        scoreBoard.text ="Stage 1" + "\n"
        + "\n"
        + "1 : " + recentRanking[0] + "\n" 
		+ "2 : " + recentRanking[1] + "\n" 
		+ "3 : " + recentRanking[2] + "\n" 
		+ "4 : " + recentRanking[3] + "\n" 
		+ "5 : " + recentRanking[4] + "\n"
		+ "6 : " + recentRanking[5] + "\n"
		+ "7 : " + recentRanking[6] + "\n"
		+ "8 : " + recentRanking[7] + "\n"
		+ "9 : " + recentRanking[8] + "\n"
		+ "10 : " + recentRanking[9] + "\n";

        scoreBoard2.text = "Stage 2" + "\n"
        + "\n"
        + "1 : " + recentRanking2[0] + "\n"
        + "2 : " + recentRanking2[1] + "\n"
        + "3 : " + recentRanking2[2] + "\n"
        + "4 : " + recentRanking2[3] + "\n"
        + "5 : " + recentRanking2[4] + "\n"
        + "6 : " + recentRanking2[5] + "\n"
        + "7 : " + recentRanking2[6] + "\n"
        + "8 : " + recentRanking2[7] + "\n"
        + "9 : " + recentRanking2[8] + "\n"
        + "10 : " + recentRanking2[9] + "\n";

        scoreBoard3.text = "Stage 3" + "\n"
        + "\n"
        + "1 : " + recentRanking3[0] + "\n"
        + "2 : " + recentRanking3[1] + "\n"
        + "3 : " + recentRanking3[2] + "\n"
        + "4 : " + recentRanking3[3] + "\n"
        + "5 : " + recentRanking3[4] + "\n"
        + "6 : " + recentRanking3[5] + "\n"
        + "7 : " + recentRanking3[6] + "\n"
        + "8 : " + recentRanking3[7] + "\n"
        + "9 : " + recentRanking3[8] + "\n"
        + "10 : " + recentRanking3[9] + "\n";
    }
}
