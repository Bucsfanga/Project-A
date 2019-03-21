using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

    [SerializeField]
    private Image ForegroundImage;
    [SerializeField]
    private float updateSpeed = 0.5f;



    private void Awake()
    {
        GetComponent<Health>().OnHealthPctChanged += HealthChanged;
    }

    private void HealthChanged (float pct)
    {
        StartCoroutine(ChangeToPct(pct));
    }

    private IEnumerator ChangeToPct (float pct)
    {
        float preChangePct = ForegroundImage.fillAmount;
        float elapsed = 0f;

        while (elapsed < updateSpeed)
        {
            elapsed += Time.deltaTime;
            ForegroundImage.fillAmount = Mathf.Lerp(preChangePct, pct, elapsed / updateSpeed);
            yield return null;
        }

        ForegroundImage.fillAmount = pct;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.LookAt(Camera.main.transform);
        transform.Rotate(0, 180, 0);
	}
}
