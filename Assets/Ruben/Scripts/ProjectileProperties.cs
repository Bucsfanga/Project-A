using UnityEngine;
using System.Collections;

public class ProjectileProperties : MonoBehaviour
{
    public float lifetime;
    public GameObject pSystem;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }
    void OnCollisionEnter(Collision collision)
    {
        //next - check if we have collided with anything but player/enemy
        if (collision.gameObject.tag == "Player") {
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
}