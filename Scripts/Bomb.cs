using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    //private float speed = 70.0f;
    private Rigidbody rb;
    public GameObject explosion; 

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
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Nemico perde vita");           
        }
        Object.Destroy(this);
        //MeshRenderer mesh = GetComponent<MeshRenderer>();
        //mesh.enabled = false;
    }
}
