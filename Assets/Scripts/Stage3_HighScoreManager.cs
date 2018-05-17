using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage3_HighScoreManager : MonoBehaviour
{

    const string RANKING_PREF_KEY3 = "ranking3";
    public int[] ranking3 = new int[10];
    int i;
    int new_score;

    void Awake()
    {
        if (PlayerPrefsX.GetIntArray(RANKING_PREF_KEY3).Length < 1)
        {
            PlayerPrefsX.SetIntArray("ranking3", new int[10]);
        }
        ranking3 = PlayerPrefsX.GetIntArray(RANKING_PREF_KEY3);
    }

    // ゴールに触れた際に新たにスコアを保存する
    void OnTriggerEnter(Collider other)
    {
        int new_score = FindObjectOfType<UIController>().score;

        int _tmp = 0;
        for (i = 0; i < ranking3.Length; i++)
        {
            if (ranking3[i] < new_score)
            {
                _tmp = ranking3[i];
                ranking3[i] = new_score;
                new_score = _tmp;
            }
        }
        PlayerPrefsX.SetIntArray("ranking3", ranking3);
        Debug.Log(PlayerPrefsX.GetIntArray("ranking3")[0]);

    }
}
