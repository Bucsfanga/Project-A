using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeSpawner : MonoBehaviour {

    public Transform[] RangeSpawnGroup;
    public GameObject Range_Low;
    int randomSpawnPoint;
    public static bool spawn;

	// Use this for initialization
	void Start ()
    {
        spawn = true;
        InvokeRepeating("SpawnRange", 3f, 5f);		
	}
	
	void SpawnRange()
    {
        if (spawn)
        {
            randomSpawnPoint = Random.Range(0, RangeSpawnGroup.Length);
            Instantiate(Range_Low, RangeSpawnGroup[randomSpawnPoint].position, Quaternion.identity);
        }
    }
}