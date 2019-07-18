using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {



    public float minY = 90.0f;
    public float maxY = 140.0f;

    public float sensX = 150.0f;
    public float sensY = 100.0f;

    public float rotationX = 0.0f;
    public float rotationY = 0.0f;

    public float offset = 1.5f;

    //public GameObject target;

    void Update()
    {

        //transform.position = new Vector3(target.transform.position.x, target.transform.position.y+ offset, target.transform.position.z);
        rotationX += Input.GetAxis("Mouse X") * sensX * Time.deltaTime;
        rotationY += Input.GetAxis("Mouse Y") * sensY * Time.deltaTime;
        rotationY = Mathf.Clamp(rotationY, minY, maxY);
        transform.localEulerAngles = new Vector3(-rotationY, rotationX , 0);

    }
}
