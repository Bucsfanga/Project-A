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

    GameObject manager;

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
        manager = GameObject.FindGameObjectWithTag("Game Manager");
        
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
            manager.GetComponent<GroundPlacement>().enemiesKilled++;
            manager.GetComponent<GroundPlacement>().credits = manager.GetComponent<GroundPlacement>().credits + 20;
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Target")
        {
            Debug.Log("ouch");
            collision.gameObject.GetComponent<TowerHealth>().health--;
            collision.gameObject.GetComponent<TowerHealth>().TakenDamage();
            Debug.Log(collision.gameObject.GetComponent<TowerHealth>().health);
            manager.GetComponent<GroundPlacement>().enemiesKilled++;
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.tag == "Player")
        {
            Debug.Log("ouch");
            Debug.Log(collision.gameObject);
            collision.gameObject.GetComponent<TowerHealth>().health--;
            collision.gameObject.GetComponent<TowerHealth>().TakenDamage();
            Debug.Log(collision.gameObject.GetComponent<TowerHealth>().health);
            manager.GetComponent<GroundPlacement>().enemiesKilled++;
            Destroy(this.gameObject);
        }
    }

    void OnCollisionStay() {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
            playerInSight = true;
        else
            playerInSight = false;
    }

    public void TakenDamage() {

        healthBar.transform.localScale = new Vector3(healthBar.transform.localScale.x / 2, 1, 1);
    }

}
