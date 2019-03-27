using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerHealth : MonoBehaviour {

    public GameObject healthBar;
    public GameObject text;

    public int health = 5;

    private void Update()
    {
        if (health <= 0)
        {
            if (this.gameObject.tag == "Target")
            {
                text.SetActive(true);
                Destroy(this.gameObject);
            }
            else text.SetActive(true);
        }
    }

    public void TakenDamage()
    {
        healthBar.transform.localScale = new Vector3(healthBar.transform.localScale.x / 2, 1, 1);
    }
}
