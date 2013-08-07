using UnityEngine;
using System.Collections;

public class SetMovementTargetDrag : MonoBehaviour {
    private Vector3 StartPoint;
    private Vector3 CurrentPoint;
    private bool StartedDrag;
    private Vector3 DragDirection;

	// Use this for initialization
	void Start () 
    {
        StartedDrag = false;
	}
	
	// Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("command")) StartDrag();
        if (StartedDrag)
        {
            SetCurrentPoint();
            SetDragDirection();
        }
    }

    private void SetDragDirection()
    {
        DragDirection = (CurrentPoint - StartPoint).normalized;
    } 

    void StartDrag()
    {
        SetStartPoint();
        StartedDrag = true;
    }


    private void SetStartPoint()
    {
        StartPoint = Input.mousePosition;
    }

    private void SetCurrentPoint()
    {
        CurrentPoint = Input.mousePosition;
    }
}
