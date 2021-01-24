using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float speed = 10.0f;
    private Rigidbody rb;
    private float multiplier = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();    
    }

    // Update is called once per frame
    void Update()
    {       
        Vector3 force = transform.forward * speed * multiplier;
        rb.AddForce(force, ForceMode.VelocityChange);    
    }

    void OnTriggerEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Nemico perde vita");
        }
        Object.Destroy(this);
    }

    void OnBecameInvisible()
    {
        Object.Destroy(this);
    }
}
