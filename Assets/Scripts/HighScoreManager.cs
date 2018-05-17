using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreManager : MonoBehaviour {

    const string RANKING_PREF_KEY = "ranking";
    public int[] ranking = new int[10];
    int i;
    int new_score;

    void Awake()
    {
        if (PlayerPrefsX.GetIntArray(RANKING_PREF_KEY).Length < 1)
        {
            PlayerPrefsX.SetIntArray("ranking", new int[10]);
        }
        ranking = PlayerPrefsX.GetIntArray(RANKING_PREF_KEY);
    }

    // ゴールに触れた際に新たにスコアを保存する
    void OnTriggerEnter(Collider other)
    {
        int new_score = FindObjectOfType<UIController>().score;
        
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
        Debug.Log(PlayerPrefsX.GetIntArray("ranking")[0]);
        
    }
}
