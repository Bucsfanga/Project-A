using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {



    private float minY = 70.0f;
    private float maxY = 150.0f;
    private float minX = -90.0f;
    private float maxX = 90.0f;
    private float sensX = 150.0f;
    private float sensY = 100.0f;
    private float rotationX = 0.0f;
    private float rotationY = 0.0f;
    private float offset = 1.5f;

    //public GameObject target;

    void Update()
    {

        //transform.position = new Vector3(target.transform.position.x, target.transform.position.y+ offset, target.transform.position.z);
        rotationX += Input.GetAxis("Mouse X") * sensX * Time.deltaTime;
        rotationY += Input.GetAxis("Mouse Y") * sensY * Time.deltaTime;
        rotationY = Mathf.Clamp(rotationY, minY, maxY);
        rotationX = Mathf.Clamp(rotationX, minX, maxX);
        transform.localEulerAngles = new Vector3(-rotationY, rotationX , 0);

    }
}
