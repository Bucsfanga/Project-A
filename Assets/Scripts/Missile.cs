/*  ╔═════════════════════════════╡  Mech Defense Force 2019 ╞══════════════════╗            
    ║ Authors:  Donald Thatcher          Email: donald.thatcher@outlook.com     ║
    ╟───────────────────────────────────────────────────────────────────────────╢░ 
    ║ Purpose:  Contorls UAV Missile System                                     ║░
    ║ Usage:    Handles drone missile launches and targets package              ║░
    ╚═══════════════════════════════════════════════════════════════════════════╝░
       ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour {

    #region Public

    public Transform target;
    public GameObject ExplosionSFX;
    #endregion

    #region Private

    private float mach = 20f;
    private float rotateSpeed = 10f;
    private Rigidbody missile;
    private bool launced;
    #endregion

    // Use this for initialization
    void Start () {
        launced = false;
        missile = GetComponent<Rigidbody>();
        target = GameObject.Find("Player").transform;
	}
	
	// Update is called once per frame
	private void FixedUpdate () {        
            Launch();     
    }

    void Launch()
    {
        missile.velocity = transform.forward * mach;
        var missileTargetRotation = Quaternion.LookRotation(target.position - missile.position);
        missile.MoveRotation(Quaternion.RotateTowards(transform.rotation, missileTargetRotation, rotateSpeed));
    }

    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(ExplosionSFX, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}


