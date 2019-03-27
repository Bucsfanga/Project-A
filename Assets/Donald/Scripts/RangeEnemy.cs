using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeEnemy : MonoBehaviour
{

    private PlayerHealth playerHealth;
    private GameObject player;
    private SphereCollider col;
    private bool firing;
    private float damage = 45f;

    public int health = 10;

    public GameObject healthBar;
    GameObject manager;


    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("PlayerObject 1");
        playerHealth = player.GetComponent<PlayerHealth>();
        manager = GameObject.FindGameObjectWithTag("Game Manager");
    }

    //    // Update is called once per frame
    //    void Update ()
    //    {
    //        float shot = anim.GetFloat(hash.shotFloat);

    //        if (shot > 0.5f && !firing)
    //            fire();

    //        if (shot <0.5f)
    //        {
    //            firing = false;
    //        }
    //	}

    private void Update()
    {
        if (health <= 0)
        {
            manager.GetComponent<GroundPlacement>().enemiesKilled++;
            manager.GetComponent<GroundPlacement>().credits = manager.GetComponent<GroundPlacement>().credits + 20;
            Destroy(this.gameObject);
        }
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {

        }
    }

    public void TakenDamage()
    {
        healthBar.transform.localScale = new Vector3(healthBar.transform.localScale.x / 2, 1, 1);
    }
}
