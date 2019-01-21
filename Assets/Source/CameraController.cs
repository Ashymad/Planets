using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float scrollModifier = 10;
    public float mouseModifier = 1;
    public float UIScale = 1;

    private Transform crosshairTransform;
    private Transform diamondTransform;

    void Start()
    {
	crosshairTransform = transform.GetChild(0).transform;
	diamondTransform = transform.GetChild(1).transform;
    }

    void Update()
    {
	float scroll = Input.GetAxis("Mouse ScrollWheel");
	
	transform.position += transform.forward*scroll*scrollModifier;

	if(Input.GetMouseButton(2))
	{
	    Vector2 mouseXY = new Vector2(
		    Input.GetAxis("Mouse X"),
		    Input.GetAxis("Mouse Y"));
	    transform.RotateAround(transform.parent.position, transform.up, mouseXY.x*mouseModifier);
	    transform.RotateAround(transform.parent.position, transform.right, -mouseXY.y*mouseModifier);
	    crosshairTransform.RotateAround(transform.position, transform.up, -mouseXY.x*mouseModifier);
	    crosshairTransform.RotateAround(transform.position, transform.right, mouseXY.y*mouseModifier);
	    crosshairTransform.LookAt(transform);
	    diamondTransform.RotateAround(transform.position, transform.up, -mouseXY.x*mouseModifier);
	    diamondTransform.RotateAround(transform.position, transform.right, mouseXY.y*mouseModifier);
	    diamondTransform.LookAt(transform);
	}
    }
}
