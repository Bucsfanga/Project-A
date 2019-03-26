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

    public GameObject healthBar;
    

    public GameObject target;
    private PlayerHealth playerHealth;
    public GameObject player;
    private SphereCollider col;

    public int health = 2;




    // Use this for initialization
    void Start ()
    {
        player = GameObject.Find("PlayerObject 1");
        target = GameObject.Find("Target");
        moveSpeed = 0.5f;
        playerHealth = player.GetComponent<PlayerHealth>();


        
	}

    // Update is called once per frame
    void Update()
    {
        if (playerInSight == true && playerHealth.health > 0f)
            AttackPlayer();
        else 
            AttackTarget();

        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }


    void AttackTarget()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.destination = target.transform.position;  
    }

    void AttackPlayer()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.destination = player.transform.position;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)      
            playerInSight = true; 
        else
            playerInSight = true;
    }

    public void TakenDamage() {

        healthBar.transform.localScale = new Vector3(healthBar.transform.localScale.x / 2, 1, 1);
    }

}
