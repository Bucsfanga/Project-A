using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {



    public float minY = -45.0f;
    public float maxY = 45.0f;


    public float sensY = 100.0f;

    public float rotationY = 0.0f;


    public GameObject target;

    void Update()
    {

        Vector3 dir = target.transform.forward;
        dir.y = 0;
        transform.forward = dir;
        //rotationX += Input.GetAxis("Mouse X") * sensX * Time.deltaTime;
        rotationY += Input.GetAxis("Mouse Y") * sensY * Time.deltaTime;
        rotationY = Mathf.Clamp(rotationY, minY, maxY);
        transform.localEulerAngles = new Vector3(-rotationY, 0, 0);
        
    }
}
