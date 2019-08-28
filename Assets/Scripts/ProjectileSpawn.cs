using UnityEngine;

public class ProjectileSpawn : MonoBehaviour {
    #region Public

    public Rigidbody projectile;
    public Transform CannonBarrel;
    public float projectileSpeed = 100;
    public float weaponRange = 100f;
    public Camera fpsCam;
    #endregion

    #region Private

    #endregion

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Create Ray from camera from middle of screen
        //ray = fpsCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));


        //Check for taget reticle of player aimimng circle to pass to projecticle
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, weaponRange))
        {
            Debug.Log(hit.transform.name);
            Rigidbody clone;
            clone = (Rigidbody)Instantiate(projectile, CannonBarrel.position, projectile.rotation);
            clone.velocity = transform.forward * projectileSpeed;
        }        
    }
}