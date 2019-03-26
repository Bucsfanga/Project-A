using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeSpawner : MonoBehaviour {

    public Transform[] RangeSpawnGroup;
    public GameObject Range_Low;
    int randomSpawnPoint;
    public static bool spawn;

    private float currentTime = 0f;
    private float startingTime = 30f;

	// Use this for initialization
	void Start ()
    {
        
        currentTime = startingTime;
        InvokeRepeating("SpawnRange", 3f, 5f);
    }

    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        print (currentTime);

        if (currentTime <= 0)
        {
            spawn = false;
        }
        else
            spawn = true;
    }

    void SpawnRange()
    {
        if (spawn)
        {
            randomSpawnPoint = Random.Range(0, RangeSpawnGroup.Length);
            Instantiate(Range_Low, RangeSpawnGroup[randomSpawnPoint].position, gameObject.transform.rotation);
        }
    }
}