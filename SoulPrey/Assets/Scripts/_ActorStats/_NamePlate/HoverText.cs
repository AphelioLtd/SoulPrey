using UnityEngine;
using System.Collections;

[RequireComponent(typeof(GUIText))]
public class HoverText : MonoBehaviour 
{
    public Transform Target;
    public Vector3 Offset = Vector3.up;
    public bool ClampToScreen = false;
    public float ClampBorderSize = 0.05f;
    public bool UseMainCamera = true;
    public Camera CamToUse;
    private Camera Cam;
    private Transform ThisTransform;
    private Transform CamTransform;

    void Start()
    {
        GetComponent<GUIText>().material.color = Color.red;
        ThisTransform = transform;
        Cam = (UseMainCamera) ? Camera.main : CamToUse;
        CamTransform = Cam.transform;
    }

    void Update()
    {
        if (ClampToScreen)
        {
            var relativePosition = CamTransform.InverseTransformPoint(Target.position);
            relativePosition.z = Mathf.Max(relativePosition.z, 1.0f);
            ThisTransform.position = Cam.WorldToViewportPoint(CamTransform.TransformPoint(relativePosition + Offset));
            ThisTransform.position = new Vector3(Mathf.Clamp(ThisTransform.position.x, ClampBorderSize, 1.0f - ClampBorderSize),
                                             Mathf.Clamp(ThisTransform.position.y, ClampBorderSize, 1.0f - ClampBorderSize),
                                            ThisTransform.position.z);
        }
        else
        {
            ThisTransform.position = Cam.WorldToViewportPoint(Target.position + Offset);
        }
    }
}
