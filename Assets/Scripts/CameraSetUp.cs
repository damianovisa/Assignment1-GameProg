using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSetUp : MonoBehaviour
{
    // public float Sensitivity {
	// 	get { return sensitivity; }
	// 	set { sensitivity = value; }
	// }
    
    public GameObject target;
    Vector3 offset;
    
    // float yRotationLimit = 88f;
    // float xRotationLimit = 88f;

    // Vector2 rotation = Vector2.zero;

    // float sensitivity = 5f;
    // const string xAxis = "Mouse X"; 
    // const string yAxis = "Mouse Y";

    void Start() {
        offset = transform.position - target.transform.position;
    }

    void LateUpdate() {
        Vector3 desiredPosition = target.transform.position + offset;
        transform.position = desiredPosition;

        // rotation.x += Input.GetAxis(xAxis) * sensitivity;
		// rotation.y += Input.GetAxis(yAxis) * sensitivity;
		// rotation.y = Mathf.Clamp(rotation.y, -yRotationLimit, yRotationLimit); 
		// var xQuat = Quaternion.AngleAxis(rotation.x, Vector3.up);
		// var yQuat = Quaternion.AngleAxis(rotation.y, Vector3.left);

		// transform.localRotation = xQuat * yQuat;
    }

}
