using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {

    [SerializeField] string sceneName;
    [SerializeField] float DelayTime;

    void OnTriggerEnter(Collider other)
    {
        StartCoroutine(this.DelayMethod(DelayTime, () =>
        {
            SceneManager.LoadScene(sceneName);
        }));
    }
}
