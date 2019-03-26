using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SM_Base : MonoBehaviour {


    public int health;
    public int damage;

    private int currenthealth;

	// Use this for initialization
	void Start ()
    {
        health = 100;
	}
	
	// Update is called once per frame
	void Update ()
    {
        //       if (health < 0)
        //       {
        //           Destroy(col.gameObject);
        //           Destroy(gameObject);
        //       else
        //           health = (currenthealth - damage);
        //       }
    }
}
