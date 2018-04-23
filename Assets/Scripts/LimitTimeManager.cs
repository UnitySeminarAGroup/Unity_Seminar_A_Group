using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LimitTimeManager : MonoBehaviour
{
    [SerializeField]
    float DelayTime;
    float LimitTime;
    UIController ui;
    void Start()
    {
        ui = FindObjectOfType<UIController>();
        LimitTime = ui.seconds;
    }

    void Update()
    {
        LimitTime = ui.seconds;
        if (LimitTime < 0.01f)
        {
            StartCoroutine(this.DelayMethod(DelayTime, () =>
            {
                SceneManager.LoadScene("Title");
            }));
        }
    }
}
