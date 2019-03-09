using UnityEngine;
using System.Collections;

public class ProjectileSpawn : MonoBehaviour
{
    public Rigidbody projectile;
    public Transform Spawnpoint;
    public float bulletSpeed;

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
        }
    }
}