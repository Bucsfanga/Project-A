/*  ╔═════════════════════════════╡  Mech Defense Force 2019 ╞══════════════════╗            
    ║ Authors:  Donald Thatcher          Email: donald.thatcher@outlook.com     ║
    ╟───────────────────────────────────────────────────────────────────────────╢░ 
    ║ Purpose:  Contorl Drone Missle mechaics                                   ║░
    ║ Usage:    Handles drone missle launches and targets package               ║░
    ╚═══════════════════════════════════════════════════════════════════════════╝░
       ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour {

    public float mach;
    public GameObject ExplosionSFX;
    private Rigidbody missle;
    private bool launched;

    // Use this for initialization
    void Start () {
        missle = GetComponent<Rigidbody>();
        launched = false;		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1")) {
            missle.isKinematic = false;
            missle.velocity = transform.forward * mach;
            launched = true;
        }
        if (launched)
            transform.rotation = Quaternion.LookRotation(missle.velocity);
	}


    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(ExplosionSFX, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}


