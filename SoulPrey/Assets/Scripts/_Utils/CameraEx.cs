using UnityEngine;
using System.Collections;

// Contains Extension Methods for the Camera Class

public class CameraEx 
{
    // Retrieves the point in world space pointed to by the mouse
    // Takes into consideration GameObject collisions
    // if no gameobject was clicked on returns Vector3.zero
    public static Vector3 ClickToWorldPoint()
    {
        Ray screenRay = Camera.main.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
        RaycastHit hitInfo;
        if (Physics.Raycast(screenRay, out hitInfo))
        {
            return hitInfo.point;
        }
        return Vector3.zero;
    }

    public static Vector3 ClickToWorldPoint(string LayerName)
    {
        Ray screenRay = Camera.main.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
        RaycastHit hitInfo;
        if (Physics.Raycast(screenRay, out hitInfo, 1000f, ( 1 << LayerMask.NameToLayer(LayerName))))
        {
            return hitInfo.point;
        }
        return Vector3.zero;
    }
	
}
