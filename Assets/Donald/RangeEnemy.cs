using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeEnemy : MonoBehaviour {


    public float damage = 45f;
    public Vector3 playerLastSighting;
    public float flashIntensity = 3f;
    public float fadeSpeed = 10f;


    private Animator anim;
    private LastPlayerSighting lastPlayerSighting;
    private PlayerHealth playerHealth;
    private Vector3 previousSighting;
    private Transform player;
    private SphereCollider col;
    private bool firing;


    // Use this for initialization
    void Start ()
    {
		
	}
 
    void Awake()
    {
        // Use to assigned varibles when gaem begins
        col = GetComponent<SphereCollider>();
        anim = GetComponent<Animator>();
        lastPlayerSighting = GameObject.FindGameObjectsWithTag(Tags.gameController).GetComponet<LastPlayerSighting>();
        playerHealth = player.GetComponent<PlayerHealth>();
        player = GameObject.FindGameObjectsWithTag(Tags.player).transform;

        //Use for when game begin enemies wont chase player
        playerLastSighting = lastPlayerSighting.resetPosition;
        previousSighting = lastPlayerSighting.resetPosition;
    }

    // Update is called once per frame
    void Update ()
    {
        float shot = anim.GetFloat(hash.shotFloat);

        if (shot > 0.5f && !firing)
            fire();

        if (shot <0.5f)
        {
            firing = false;
        }
	}

}
