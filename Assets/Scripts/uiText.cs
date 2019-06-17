using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class uiText : MonoBehaviour {

    public GameObject manager;

    public Text creditCount;
    public Text enemyCount;
    public int creditText;
    public int enemyText;

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        creditText = manager.GetComponent<GroundPlacement>().credits;
        enemyText = manager.GetComponent<GroundPlacement>().enemiesKilled;
        creditCount.text = "Credits: " + creditText;
        enemyCount.text = "Enemies Killed: " + enemyText;
	}
}
