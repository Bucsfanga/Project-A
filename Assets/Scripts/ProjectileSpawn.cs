using UnityEngine;

public class ProjectileSpawn : MonoBehaviour
{
    public Rigidbody projectile;
    public Transform CannonBarrel;
    public float projectileSpeed = 100;
    public float weaponRange = 50f;



    private Camera fpsCam;
    private Ray ray;
    private LineRenderer linesight;

    // Use this for initialization
    void Start()
    {
        linesight = GetComponent<LineRenderer> ();
        fpsCam = GetComponentInParent<Camera> ();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            // Create Ray from camera from middle of screen
            ray = fpsCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;
            //Check for taget reticle of player aimimng circle to pass to projecticle
            Vector3 aimPoint;
            if (Physics.Raycast(ray, out hit))
                aimPoint = hit.point;
            else
                aimPoint = ray.GetPoint(1000);
            //Creates prokjectile being fire by player and sineds it to aim center fo screen
            Rigidbody clone;
            clone = (Rigidbody)Instantiate(projectile, CannonBarrel.position, projectile.rotation);

            clone.velocity = (aimPoint - CannonBarrel.transform.position).normalized * projectileSpeed;
        }
    }
}