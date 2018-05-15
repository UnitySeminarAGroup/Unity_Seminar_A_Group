using UnityEngine;

public class GateSwitch : MonoBehaviour
{
    [SerializeField] Transform TargetGate;
    [SerializeField] Vector3 StartPosition, EndPosition;
    [SerializeField] float MoveRate;
    bool IsMoving = false;
    void Start ()
    {
        if (!TargetGate)
        {
            this.enabled = false;
        }
        else
        {
            TargetGate.position = StartPosition;
        }
    }
    void Update ()
    {
        if (IsMoving)
        {
            TargetGate.position = Vector3.Lerp (TargetGate.position, EndPosition, MoveRate);
        }
    }
    void OnTriggerEnter (Collider collider)
    {
        if (collider.tag == "PlayerHand")
        {
            IsMoving = true;
        }
    }
}