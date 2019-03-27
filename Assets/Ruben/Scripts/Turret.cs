using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

    private GameObject target;
    private bool targetLocked;
    public float fireTimer;
    private bool shotReady;

    public GameObject turretTopPart;
    public GameObject bulletSpawnPoint;
    public GameObject bullet;

    private void Start()
    {
        shotReady = true;
    }

    private void Update()
    {
        if (targetLocked && target != null) {

            turretTopPart.transform.LookAt(target.transform);

            if (shotReady) {
                Shoot();
            }
            
        }
    }

    void Shoot() {
        Transform _bullet = Instantiate(bullet.transform, bulletSpawnPoint.transform.position, Quaternion.identity);
        _bullet.transform.rotation = bulletSpawnPoint.transform.rotation;
        shotReady = false;
        StartCoroutine(FireRate());
    }

    IEnumerator FireRate() {
        yield return new WaitForSeconds(fireTimer);
        shotReady = true;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Melee Enemy") {
            if (target)
            {
                targetLocked = true;
            }
            else
                targetLocked = false;

            if (targetLocked == false) {
                target = other.gameObject;
            }
        }
    }
}
