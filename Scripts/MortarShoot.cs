using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MortarShoot : MonoBehaviour
{
    private float shotTime ;
    private float fireRate = 60f;
    public float shootAngle = 45f;
    public GameObject prefab;
    private Transform target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        shotTime += Time.deltaTime;

        if (shotTime >= fireRate)
        {
            GameObject cannonBall = Instantiate(prefab, this.transform.position, Quaternion.identity) as GameObject;
            Rigidbody rbBall = GetComponent<Rigidbody>();
            rbBall.velocity = BallisticVelocity(target, shootAngle);
            shotTime = 0.0f;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            target = other.transform;
        }
        
    }

    Vector3 BallisticVelocity(Transform target, float angle)
    {
        Vector3 dir = target.position - this.transform.position; // get Target Direction
        float height = dir.y; // get height difference
        dir.y = 0; // retain only the horizontal direction
        float dist = dir.magnitude; // get horizontal distance
        float a = angle * Mathf.Deg2Rad; // Convert angle to radians
        dir.y = dist * Mathf.Tan(a); // set dir to the elevation angle.
        dist += height / Mathf.Tan(a); // Correction for small height differences

        // Calculate the velocity magnitude
        float velocity = Mathf.Sqrt(dist * Physics.gravity.magnitude / Mathf.Sin(2 * a));
        return velocity * dir.normalized; // Return the velocity vector.
    }
}
