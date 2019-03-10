using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : MonoBehaviour {

    Animator animator;
    public Collider coll;

    // Use this for initialization
    void Start () {

        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            if (Input.GetButton("Fire2"))
            {
                animator.SetBool("meleeStart", true);
            }
        }
        else if (animator.GetCurrentAnimatorStateInfo(0).IsName("Melee")) {
            animator.SetBool("meleeStart", false);
        }

    }
}
