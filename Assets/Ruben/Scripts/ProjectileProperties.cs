using UnityEngine;
public class ProjectileProperties : MonoBehaviour
{
    public float lifetime;
    public GameObject pSystem;

    public float damage;

    public bool isPlayer;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }
    void OnCollisionEnter(Collision collision)
    {
        

        if (isPlayer)
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
        else if (!isPlayer) {

                            //Enemy Bullet Behaviour here.
            return;         //Delete this return when starting.
        }
    }
    
}