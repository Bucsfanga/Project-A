using UnityEngine.SceneManagement;
using UnityEngine;

public class Restart : MonoBehaviour {

    public bool canRestart = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (canRestart) {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("MainMenu");
            }
        }
	}
}
