using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    public int health = 100;
    //public Vector3 LastPlayerSighting;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {

        //LastPlayerSighting = new Vector3 find.get

        if (health == 0) {
            Destroy(this.gameObject);
        }
	}
}
