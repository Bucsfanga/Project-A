using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeSpawner : MonoBehaviour {

    public Transform[] MeleeSpawnGroup;
    public GameObject MEnemy;
    int randomSpawnPoint;
    public static bool spawn;

    // Use this for initialization
	void Start ()
    {
        spawn = true;
        InvokeRepeating("SpawnMelee", 0f, 2f);
	}

    void SpawnMelee()
    {
        if (spawn)
        {
            randomSpawnPoint = Random.Range(0, MeleeSpawnGroup.Length);
            Instantiate(MEnemy, MeleeSpawnGroup[randomSpawnPoint].position, Quaternion.identity);
        }
    }
g}