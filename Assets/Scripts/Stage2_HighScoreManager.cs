using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage2_HighScoreManager : MonoBehaviour
{

    const string RANKING_PREF_KEY2 = "ranking2";
    public int[] ranking2 = new int[10];
    int i;
    int new_score;

    void Awake()
    {
        if (PlayerPrefsX.GetIntArray(RANKING_PREF_KEY2).Length < 1)
        {
            PlayerPrefsX.SetIntArray("ranking2", new int[10]);
        }
        ranking2 = PlayerPrefsX.GetIntArray(RANKING_PREF_KEY2);
    }

    // ゴールに触れた際に新たにスコアを保存する
    void OnTriggerEnter(Collider other)
    {
        int new_score = FindObjectOfType<UIController>().score;

        int _tmp = 0;
        for (i = 0; i < ranking2.Length; i++)
        {
            if (ranking2[i] < new_score)
            {
                _tmp = ranking2[i];
                ranking2[i] = new_score;
                new_score = _tmp;
            }
        }
        PlayerPrefsX.SetIntArray("ranking2", ranking2);
        Debug.Log(PlayerPrefsX.GetIntArray("ranking2")[0]);

    }
}
