using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationStateController : MonoBehaviour
{

    Animator animator;
    int isWalkingHash;
    int isRunningHash;
    bool isRunning;
    bool isWalking;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");
        bool isRunning = animator.GetBool(isRunningHash);
        bool isWalking = animator.GetBool(isWalkingHash);
    }

    // Update is called once per frame
    void Update()
    {       
         
        if (!isWalking && rb.velocity.magnitude < 0.4f)
        {
            animator.SetBool(isWalkingHash, true);
        }

        
        if (isWalking && rb.velocity.magnitude< 0.1f)
        {
            animator.SetBool(isWalkingHash, false);
        }

        if (!isRunning && rb.velocity.magnitude >= 0.4f)
        {
            
            animator.SetBool(isRunningHash, true);
        }

        if (isRunning && rb.velocity.magnitude < 0.4f)
        {
            animator.SetBool(isRunningHash, false);
        }

        /*if (isRunning && rb.velocity.x) horizontal axis
        {

        }*/

       
    }
       
        
        
        
        
        
     

}
