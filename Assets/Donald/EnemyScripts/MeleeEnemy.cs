using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/public class MeleeEnemy : MonoBehaviour {

    public float fieldOfViewAngle = 110f;
    public bool playerInSight;
    public Vector3 playerLastSighting;
    
   
    private SphereCollider col;
    private Animator anim;
    private LastPlayerSighting lastPlayerSighting;
    private PlayerHealth playerHealth;
    private GameObject player;
    private Vector3 previousSighting;
    private GameObject tower;




    // Use this for initialization
    void Start ()
    {
        		
	}

    // Use to assigned varibles 
    void Awake()
    {
        col = GetComponent<SphereCollider>();
        anim = GetComponent<Animator>();
        lastPlayerSighting = GameObject.Find("PlayerObject 1").GetComponet<LastPlayerSighting>();
        playerHealth = player.GetComponent<PlayerHealth>();
        player = GameObject.FindGameObjectWithTag("Player");

        //Use for when game begin enemies wont chase player
        playerLastSighting = lastPlayerSighting.resetPosition;
        previousSighting = lastPlayerSighting.resetPosition;
    }



    // Update is called once per frame
    void Update ()
    {

        if (lastPlayerSighting.position != previousSighting)
            playerLastSighting = lastPlayerSighting.position;

        previousSighting = lastPlayerSighting.position;

        if (playerHealth.health > 0f)
            anim.SetBool(hash.playerInSightBool, playerInSight);
        else
            anim.SetBool(hash.playerInSightBool, false);
    }

    void Attack()
    {

    }

    void RuntoTower()
    {

    }
    
    void Chaseplayer()
    {

    }

    void OnTriggerStay(Collider other)
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
                        lastPlayerSighting.position = player.transform.position;
                    }
                }
            }
        }
    }
}
