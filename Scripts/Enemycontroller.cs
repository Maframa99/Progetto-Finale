using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemycontroller : MonoBehaviour
{
    public Transform destination;
    private NavMeshAgent navMesh;

    // Start is called before the first frame update
    void Start()
    {
        navMesh = GetComponent<NavMeshAgent>();
        navMesh.destination = new Vector3(destination.position.x, destination.position.y, destination.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.x - destination.position.x < 0.02 && this.transform.position.z - destination.position.z < 0.02)
        {
            Rigidbody rb = this.GetComponent<Rigidbody>();
            rb.velocity = new Vector3(0,0,0);
        }
    }
}
