using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointControllerRH : MonoBehaviour
{

    public int scoreRH;


    // Use this for initialization
    void Start()
    {
        scoreRH = 0;

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Point5")
        {
            scoreRH += 5;
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Point10")
        {
            scoreRH += 10;
            Destroy(other.gameObject);
        }
    }
}