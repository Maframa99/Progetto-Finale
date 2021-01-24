using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public SphereCollider sphColl;
    public float width = 20.0f;
    public GameObject projPrefab;
    private bool isShooting= false;
    private float delay = 2.0f;
    private GameObject nemico;
    private float angle = 45f;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("A");
        //Transform enemyTransform = other.transform;
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("B");
            nemico = other.gameObject;
            isShooting = true;    
            //Invoke("shoot", delay);
            StartCoroutine("shoot");
        }
            //StopCoroutine("shoot");
    }

    void onTriggerExit(Collider other)
    {
        isShooting = false;
    }

    IEnumerator shoot()
    {
        Debug.Log("Coroutine");
        while (isShooting)
        {
            transform.LookAt(nemico.transform.position);
            Vector3 dir = nemico.transform.position - this.transform.position; // get Target Direction
            float height = dir.y; // get height difference
            dir.y = 0; // retain only the horizontal direction
            float dist = dir.magnitude; // get horizontal distance
            float a = angle * Mathf.Deg2Rad; // Convert angle to radians
            dir.y = dist * Mathf.Tan(a); // set dir to the elevation angle.
            dist += height / Mathf.Tan(a); // Correction for small height differences
            float velocity = Mathf.Sqrt(dist * Physics.gravity.magnitude / Mathf.Sin(2 * a));


            GameObject clone = Instantiate(projPrefab, this.transform.position, this.transform.rotation);
            Rigidbody cloneRigidbody = clone.GetComponent<Rigidbody>();
            cloneRigidbody.velocity = Mathf.Sqrt(dist * Physics.gravity.magnitude / Mathf.Sin(2 * a)) * dir.normalized;

            yield return new WaitForSeconds(delay);
        }
        StopCoroutine("shoot");
    }

    void OnDrawGizmos()
    {
        sphColl.radius = width;
    }
}
