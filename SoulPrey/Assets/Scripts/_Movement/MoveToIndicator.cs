using UnityEngine;
using System.Collections;

public class MoveToIndicator : MonoBehaviour 
{
    public Light LightIndicator;

	// Use this for initialization
	void Start () 
    {
	    
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    void OnUpdateTarget(Vector3 Position)
    {
        if (LightIndicator != null)
        {
            LightIndicator.transform.position = new Vector3(Position.x, 0.5f, Position.z);
            LightIndicator.animation.Play("PositionIndicatorFlash");
        }
    }
}
