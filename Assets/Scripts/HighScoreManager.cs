using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreManager : MonoBehaviour {

    const string RANKING_PREF_KEY = "ranking";
    public int[] ranking = new int[10];
    int i;
    int new_score;

    // ゴールに触れた際に新たにスコアを保存する
    void OnTriggerEnter(Collider other)
    {
        int new_score = GetComponent<UIController>().score;
        
        int _tmp = 0;
        for (i = 0; i < ranking.Length; i++)
        {
            if (ranking[i] < new_score)
            {
                _tmp = ranking[i];
                ranking[i] = new_score;
                new_score = _tmp;
            }
        }
        PlayerPrefsX.SetIntArray("ranking", ranking);
        
    }
}
