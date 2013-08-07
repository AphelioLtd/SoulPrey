using UnityEngine;
using System.Collections;

public class SetMovementTargetObject : MonoBehaviour 
{
    public GameObject TargetObject;
    public bool TrackingTarget;
    public bool ReachedTarget;
    public bool ReachedTargetLast;
    public float SensorDistance = 50;
    public float MoveSpeed = 1;
    public float StopDistance = 1;

	// Use this for initialization
	void Start () 
    {
        TrackingTarget = false;
	}
	
	// Update is called once per frame
	void Update () 
    {
        TrackingTarget = CanSeeTarget();
        ReachedTargetLast = ReachedTarget;
        ReachedTarget = Vector3.Distance(transform.position, TargetObject.transform.position) < StopDistance;
        if (ReachedTarget && !ReachedTargetLast) ReachTarget();
	}

    private void ReachTarget()
    {
        // Do Stuff to Target
        SendMessage("BasicAttackLoop",TargetObject,SendMessageOptions.DontRequireReceiver);
    }

    void FixedUpdate()
    {
        if (TrackingTarget && !ReachedTarget) MoveToTarget();
    }

    private void MoveToTarget()
    {
        Vector3 targetDirection = (TargetObject.transform.position - transform.position).normalized;
        targetDirection.y = 0;
        transform.Translate(targetDirection * Time.deltaTime * MoveSpeed);
    }

    private bool CanSeeTarget()
    {
        return TargetObject != null && Vector3.Distance(TargetObject.transform.position, transform.position) < SensorDistance;
    }
}
