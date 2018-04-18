using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootController : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    private void Start()
    {
        if(audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "AddPoint")
        {
            int p = other.GetComponent<PointController>().ScorePoint;
            FindObjectOfType<UIController>().score += p;
            Destroy(other.gameObject);
            audioSource.Play();
        }
    }
}
