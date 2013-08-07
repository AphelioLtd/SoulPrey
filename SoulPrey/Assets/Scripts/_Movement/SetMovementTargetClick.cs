using UnityEngine;
using System.Collections;

public class SetMovementTargetClick : MonoBehaviour 
{
    private Vector3 MoveTarget;
    public float StopDistance = 1;
    public float MoveSpeed = 1;
    public bool Moving;
    public GameObject testCube;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Command")) ExecuteCommand();
    }

    void FixedUpdate()
    {
        if (MoveTarget != null && Moving)
        {
            if (Vector3.Distance(MoveTarget, transform.position) < StopDistance) ReachTarget();
            else PursueTarget();
        }
    }

    private void PursueTarget()
    {
        Vector3 TargetDirection = (MoveTarget - transform.position).normalized;
        TargetDirection.y = 0;
        transform.Translate(TargetDirection * MoveSpeed);
    }

    private void ReachTarget()
    {
        StopMoving();
    }

    private void StopMoving()
    {
        MoveTarget = transform.position;
        Moving = false;
    }

    private void ExecuteCommand()
    {
        Vector3 worldTarget = CameraEx.ClickToWorldPoint("Floor");
        if (worldTarget != Vector3.zero)
        {
            MoveTarget = worldTarget;
            Moving = true;
            SendMessage("OnUpdateTarget", MoveTarget);
        }
    }
}
