using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float scrollModifier = 10;
    public float mouseModifier = 1;
    public float UIScale = 1;

    void Update()
    {
	float scroll = Input.GetAxis("Mouse ScrollWheel");
	this.transform.position += transform.forward*scroll*scrollModifier;
	var crosshairTransform = transform.parent.GetChild(1).transform;
	var diamondTransform = transform.parent.GetChild(2).transform;
	crosshairTransform.localScale -= Vector3.one*scroll*scrollModifier*UIScale;
	diamondTransform.localScale -= Vector3.one*scroll*scrollModifier*UIScale;
	crosshairTransform.position -= crosshairTransform.forward*scroll*scrollModifier;
	diamondTransform.position += diamondTransform.forward*scroll*scrollModifier;

	if(Input.GetMouseButton(2))
	{
	    Vector2 mouseXY = new Vector2(
		    Input.GetAxis("Mouse X"),
		    Input.GetAxis("Mouse Y"));
	    transform.RotateAround(transform.parent.position, transform.up, mouseXY.x*mouseModifier);
	    transform.RotateAround(transform.parent.position, transform.right, -mouseXY.y*mouseModifier);
	}
    }
}
