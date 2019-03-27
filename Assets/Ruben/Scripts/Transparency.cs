using UnityEngine;

public class Transparency : MonoBehaviour {

    public GameObject gm;

    Color color;

    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("Game Manager");
        color = gameObject.GetComponent<MeshRenderer>().material.color;
        color.a = 1.0f;
    }

    // Update is called once per frame
    void Update () {
        if (gm.GetComponent<GroundPlacement>().isBeingPlaced == false)
        {

            this.GetComponent<MeshRenderer>().material.color = color;
            Destroy(this);
        }
	}
}
