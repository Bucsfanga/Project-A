using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeSpawner : MonoBehaviour {

    public Transform[] MeleeSpawnGroup;
    public GameObject Melee_Low;
    int randomSpawnPoint;
    public static bool spawn;

    private float currentTime = 0f;
    private float startingTime = 30f;

    // Use this for initialization
    void Start ()
    {
        
        currentTime = startingTime;
        InvokeRepeating("SpawnMelee", 0f, 2f);
    }

    void Update()
    {
        currentTime -= 1 * Time.deltaTime;

        if (currentTime <= 0)
        {
            spawn = false;
        }
        else
            spawn = true;
    }

    void SpawnMelee()
    {
        if (spawn)
        {
            randomSpawnPoint = Random.Range(0, MeleeSpawnGroup.Length);
            Instantiate(Melee_Low, MeleeSpawnGroup[randomSpawnPoint].position, gameObject.transform.rotation);
        }
    }
}