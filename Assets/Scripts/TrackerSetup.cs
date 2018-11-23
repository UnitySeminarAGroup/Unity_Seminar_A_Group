using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class TrackerSetup : MonoBehaviour
{
    [SerializeField] Transform Head;
    [SerializeField] List<Transform > Ctrls;
    [SerializeField] GameObject RHModel, LHModel, RFModel, LFModel;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            Calibrate();
            Debug.Log("Calibrated");
        }
    }
    void Calibrate()
    {
        List<Transform> sorted = Ctrls.OrderByDescending(x => x.transform.position.y).ToList();
        Transform hand0 = sorted[0];
        Transform hand1 = sorted[1];
        Vector3 dir0 = hand0.position - (hand0.position + hand1.position) / 2;
        Vector3 dir1 = hand1.position - (hand0.position + hand1.position) / 2;
        float dot0 = Vector3.Dot(dir0, Head.right);
        float dot1 = Vector3.Dot(dir1, Head.right);
        if(dot0 > dot1)
        {
            RHModel.transform.parent = hand0;
            LHModel.transform.parent = hand1;
        }
        else
        {
            RHModel.transform.parent = hand1;
            LHModel.transform.parent = hand0;
        }
        Transform foot0 = sorted[2];
        Transform foot1 = sorted[3];
        Vector3 dir2 = foot0.position - (foot0.position + foot1.position) / 2;
        Vector3 dir3 = foot1.position - (foot0.position + foot1.position) / 2;
        float dot2 = Vector3.Dot(dir2, Head.right);
        float dot3 = Vector3.Dot(dir3, Head.right);
        if (dot2 > dot3)
        {
            RFModel.transform.parent = foot0;
            LFModel.transform.parent = foot1;
        }
        else
        {
            RFModel.transform.parent = foot1;
            LFModel.transform.parent = foot0;
        }
    }
}
