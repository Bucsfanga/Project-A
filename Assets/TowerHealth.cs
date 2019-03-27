using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerHealth : MonoBehaviour {

    public GameObject healthBar;
    public GameObject text;
    public GameObject[] meleeObjectsToDisable;
    public GameObject[] rangedObjectsToDisable;
    public GameObject gm;

    public int health = 5;

    private void Update()
    {
        if (health <= 0)
        {
            meleeObjectsToDisable = GameObject.FindGameObjectsWithTag("Melee Enemy");
            rangedObjectsToDisable = GameObject.FindGameObjectsWithTag("Ranged Enemy");
            if (this.gameObject.tag == "Target")
            {
                foreach (var obj in meleeObjectsToDisable)
                {
                    obj.SetActive(false);
                    continue;
                }
                foreach (var obj in rangedObjectsToDisable)
                {
                    obj.SetActive(false);
                    continue;
                }
                text.SetActive(true);
                gm.GetComponent<Restart>().canRestart = true;
                Destroy(this.gameObject);
            }
            else if (this.gameObject.tag == "Player")
            {
                
                foreach (var obj in meleeObjectsToDisable)
                {
                    obj.SetActive(false);
                    continue;
                }
                foreach (var obj in rangedObjectsToDisable)
                {
                    obj.SetActive(false);
                    continue;
                }
                gm.GetComponent<Restart>().canRestart = true;
                text.SetActive(true);
            }
        }
    }

    public void TakenDamage()
    {
        healthBar.transform.localScale = new Vector3(healthBar.transform.localScale.x / 2, 1, 1);
    }
}
