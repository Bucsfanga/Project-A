using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeAI : MonoBehaviour {

    public float fieldOfViewAngle = 110f;
    public bool playerInSight;
    public Vector3 playerLastSighting;
    

    private SphereCollider col;
    private Animator anim;
    private LastPlayerSighting lastPlayerSighting;
    private PlayerHealth playerHealth;
    private GameObject player;
    private Vector3 previousSighting;

	// Use this for initialization
	void Start () {
		
	}

    // Use to assigned varibles 
    void Awake()
    {
        col = GetComponent<SphereCollider>();
        anim = GetComponent<Animator>();
        lastPlayerSighting = GameObject.FindGameObjectsWithTag(Tags.gameController).GetComponet<LastPlayerSighting>();
        playerHealth = player.GetComponent<PlayerHealth>();
        player = GameObject.FindGameObjectsWithTag(Tags.player);

        //Use for when game begin enemies wont chase player
        playerLastSighting = lastPlayerSighting.resetPosition;
        previousSighting = lastPlayerSighting.resetPosition;
    }



    // Update is called once per frame
    void Update () {

        if (lastPlayerSighting.position != previousSighting)
            playerLastSighting = lastPlayerSighting.position;

        previousSighting = lastPlayerSighting.position;

        if(playerHealth.health > 0f)
            anim.SetBool()
	}
}
