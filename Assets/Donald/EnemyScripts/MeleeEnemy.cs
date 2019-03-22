﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MeleeEnemy : MonoBehaviour {

    public float fieldOfViewAngle = 110f;
    public bool playerInSight;
    public Vector3 directionToGate;
    public Vector3 directionToPlayer;
    public float moveSpeed;


    private GameObject gate;
    private PlayerHealth playerHealth;
    private GameObject player;
    private SphereCollider col;
    private NavMeshAgent nav;




    // Use this for initialization
    void Start ()
    {
        player = GameObject.Find("PlayerObject 1");
        gate = GameObject.Find("SM_MainGate");
        moveSpeed = 10f;
        playerHealth = player.GetComponent<PlayerHealth>();
        nav = GetComponent<NavMeshAgent>();
	}

    // Update is called once per frame
    void Update()
    {
        if (playerInSight == true && playerHealth.health > 0f)
            AttackPlayer();
        else 
            AttackGate();
    }


    void AttackGate()
    {
        nav.destination = gate.transform.position;
        
        {

        }
    }

    void AttackPlayer()
    {
        nav.destination = player.transform.position;
        
        {

        }
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    //ContactPoint contact = collision.contacts[0];
    //    ////Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
    //    ////Vector3 pos = contact.point;
    //    //Destroy(gameObject);
    //}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player)
        {
            playerInSight = false;
            Vector3 direction = other.transform.position - transform.position;
            float angle = Vector3.Angle(direction, transform.forward);

            if(angle < fieldOfViewAngle * 0.5f)
            {
                RaycastHit hit;

                if(Physics.Raycast(transform.position + transform.up, direction.normalized, out hit, col.radius))
                {
                    if(hit.collider.gameObject == player)
                    {
                        playerInSight = true;                
                    }
                }
            }
        }
    }
}
