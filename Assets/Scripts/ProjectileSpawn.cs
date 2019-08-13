using UnityEngine;

public class ProjectileSpawn : MonoBehaviour
{
    public Rigidbody projectile;
    public Transform Spawnpoint;
    public float bulletSpeed = 30;
    public float weaponRange = 50f;


    private Camera fpsCam;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Rigidbody clone;
            clone = (Rigidbody)Instantiate(projectile, Spawnpoint.position, projectile.rotation);

            clone.velocity = Spawnpoint.TransformDirection(Vector3.forward * bulletSpeed);
            Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;

            if(Physics.Raycast(rayOrigin,fpsCam.transform.forward, out hit, weaponRange))
            {
                hit.point;
            }
        }
    }
}