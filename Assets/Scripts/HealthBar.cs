using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

    private HealthBarSystem healthBarSystem;

    public void Setup(HealthBarSystem healthBarSystem)
    {
        this.healthBarSystem = healthBarSystem;

        healthBarSystem.OnHealthChanged += HealthBarSystem_OnHealthChanged;
    }

    private  void HealthBarSystem_OnHealthChanged(object sender, System.EventArgs e){
        transform.Find("Bar").localScale = new Vector3(healthBarSystem.GetHealthPercent(), 1);
    }
	
	// Update is called once per frame
	private void Update ()
    {
        
	}
}
