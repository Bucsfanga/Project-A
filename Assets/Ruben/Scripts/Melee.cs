using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : MonoBehaviour {

    Animator animator;
    CapsuleCollider col;



    // Use this for initialization
    void Start () {

        col = GetComponent<CapsuleCollider>();
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
    bool EnemyHit()
    {

        float distanceToPoints = col.height / 2 - col.radius;
        float radius = col.radius * 0.95f;

        Vector3 point1 = transform.position + col.center + Vector3.up * distanceToPoints;
        Vector3 point2 = transform.position + col.center - Vector3.up * distanceToPoints;

        RaycastHit[] hits = Physics.CapsuleCastAll(point1, point2, radius, transform.forward, 0);

        foreach(RaycastHit objectHit in hits)
        {
            if (objectHit.transform.tag == "Enemy") {
                print("enemy hit");
                return true;
            }
        }
        return false;
    }
}
