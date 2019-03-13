using UnityEngine;
using System.Collections;

public class ProjectileProperties : MonoBehaviour
{
    public float lifetime;
    public GameObject pSystem;

    public float damage;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }
    void OnCollisionEnter(Collision collision)
    {
        if (this.gameObject.tag == "Player")
        {

            if (collision.gameObject.tag == "Player")
            {
                Debug.Log("spawn");
            }
            else if (collision.gameObject.tag == "Enemy")
            {
                Debug.Log("ouch");
                Destroy(this.gameObject);
            }
            else
            {
                Debug.Log("hit");
                Instantiate(pSystem, this.transform);
                this.transform.DetachChildren();
                Destroy(this.gameObject);
            }
        }
        else if (this.gameObject.tag == "Enemy") {

                            //Enemy Bullet Behaviour here.
            return;         //Delete this return when starting.
        }
    }
    
}