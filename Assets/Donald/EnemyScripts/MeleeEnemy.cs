using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MeleeEnemy : MonoBehaviour {

    public float fieldOfViewAngle = 110f;
    public bool playerInSight;
    public Vector3 directionToTarget;
    public Vector3 directionToPlayer;
    public float moveSpeed;
    

    private GameObject target;
    private PlayerHealth playerHealth;
    private GameObject player;
    private SphereCollider col;
    private NavMeshAgent nav;




    // Use this for initialization
    void Start ()
    {
        player = GameObject.Find("PlayerObject 1");
        target = GameObject.Find("Target");
        moveSpeed = 0.5f;
        playerHealth = player.GetComponent<PlayerHealth>();
        nav = GetComponent<NavMeshAgent>();
	}

    // Update is called once per frame
    void Update()
    {
        if (playerInSight == true && playerHealth.health > 0f)
            AttackPlayer();
        else 
            AttackTarget();
    }


    void AttackTarget()
    {
        directionToTarget = target.transform.position - transform.position;
        directionToTarget = directionToTarget.normalized;
        transform.Translate(directionToTarget * moveSpeed, Space.World);
        
    }

    void AttackPlayer()
    {
        directionToPlayer = player.transform.position - transform.position;
        directionToPlayer = directionToPlayer.normalized;
        transform.Translate(directionToPlayer * moveSpeed, Space.World);
                
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch (col.gameObject.tag)
        {
            case "Player":
                Destroy(col.gameObject);
                Destroy(gameObject);
                break;

            case "Sword":
                Destroy(col.gameObject);
                Destroy(gameObject);
                break;

            case "Bullet":
                Destroy(col.gameObject);
                Destroy(gameObject);
                break;

            case "Target":
                Destroy(col.gameObject);
                Destroy(gameObject);
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)      
            playerInSight = true; 
        else
            playerInSight = false;
    }

}
