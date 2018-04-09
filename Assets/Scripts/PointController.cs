using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointController : MonoBehaviour
{
    public int score;

    // Use this for initialization
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Point5")
        {
            score += 5;
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Point10")
        {
            score += 10;
            Destroy(other.gameObject);
        }
    }
}
    
