/*  ╔═════════════════════════════╡  Mech Defense Force 2019 ╞══════════════════╗            
    ║ Authors:  Donald Thatcher          Email: donald.thatcher@outlook.com     ║
    ╟───────────────────────────────────────────────────────────────────────────╢░ 
    ║ Purpose:  Contorls UAV Orbit System                                       ║░
    ║ Usage:    Handles UAV launch and Orbit fuctions                           ║░
    ╚═══════════════════════════════════════════════════════════════════════════╝░
       ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UAVBehavior : MonoBehaviour {
    #region Public   
    public Transform centerPoint;
    #endregion

    #region Private
    private float timer;
    private float height;
    private float orbitSpeed;
    private float xRadius;
    private float zRadius;
    #endregion


    // Use this for initialization
    void Start () {
        timer = 0f;
        height = 50f;
        orbitSpeed = .5f;
        xRadius = 50f;
        zRadius = 50f;
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime * orbitSpeed;
        Orbit();
        //transform.LookAt(centerPoint);
	}

    // This fuctions controls the orbital pattern of UAV clockwise around player
    void Orbit()
    {
        float x = -Mathf.Cos(timer) * xRadius;
        float z = Mathf.Sin(timer) * zRadius;
        Vector3 pos = new Vector3(x, height, z);
        transform.position = pos + centerPoint.position;
    }
}
