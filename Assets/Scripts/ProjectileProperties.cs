using UnityEngine;
public class ProjectileProperties : MonoBehaviour {
    public float lifetime;
    public GameObject pSystem;

    public float damage;
    public bool isPlayer;


    void Start()
    {
        
    }
    void OnCollisionEnter(Collision collision)
    {
        

        if (isPlayer)
        {

            if (collision.gameObject.tag == "Player")
            {
                Debug.Log("spawn");
            }
            else if (collision.gameObject.tag == "Melee Enemy")
            {
                Debug.Log("ouch");
                collision.gameObject.GetComponent<MeleeEnemy>().health--;
                collision.gameObject.GetComponent<MeleeEnemy>().TakenDamage();
                Debug.Log(collision.gameObject.GetComponent<MeleeEnemy>().health);
                Destroy(this.gameObject);
            }
            else if (collision.gameObject.tag == "Ranged Enemy")
            {
                Debug.Log("ouch");
                collision.gameObject.GetComponent<RangeEnemy>().health--;
                collision.gameObject.GetComponent<RangeEnemy>().TakenDamage();
                Debug.Log(collision.gameObject.GetComponent<RangeEnemy>().health);
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