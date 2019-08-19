using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

    public float weaponRange = 50f;
    private Camera fpsCam;

    private float minY = 70.0f;
    private float maxY = 150.0f;
    private float minX = -90.0f;
    private float maxX = 90.0f;
    private float sensX = 150.0f;
    private float sensY = 100.0f;
    private float rotationX = 0.0f;
    private float rotationY = 0.0f;
    private float offset = 1.5f;

    void Start()
    {
        fpsCam = GetComponentInChildren<Camera>();
    }

    void Update()
    {
        Vector3 lineOrgin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
        Debug.DrawRay(lineOrgin, fpsCam.transform.forward * weaponRange, Color.green);

        //transform.position = new Vector3(target.transform.position.x, target.transform.position.y+ offset, target.transform.position.z);
        rotationX += Input.GetAxis("Mouse X") * sensX * Time.deltaTime;
        rotationY += Input.GetAxis("Mouse Y") * sensY * Time.deltaTime;
        rotationY = Mathf.Clamp(rotationY, minY, maxY);
        rotationX = Mathf.Clamp(rotationX, minX, maxX);
        transform.localEulerAngles = new Vector3(-rotationY, rotationX , 0);

    }
}
