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


    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("PlayerObject 1");
        playerHealth = player.GetComponent<PlayerHealth>();
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
