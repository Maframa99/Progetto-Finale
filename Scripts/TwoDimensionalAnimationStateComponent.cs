using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoDimensionalAnimationStateComponent : MonoBehaviour


{
    Animator animator;
    float velocityZ = 0.0f;
    float velocityX = 0.0f;
    public float acceleration = 2.0f;
    public float deceleration = 2.0f;
    public float maximumWalkVelocity = 0.5f;
    public float maximumRunVelocity = 2.0f;

    // increase performance
    int VelocityZHash;
    int VelocityXHash;

    private Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        // search the gameobject this script is attached to and get the animator component
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        // increase performance
        VelocityZHash = Animator.StringToHash("Velocity Z");
        VelocityXHash = Animator.StringToHash("Velocity X");
    }

    // handles acceleration and deceleration
    void changeVelocity (float currentMaxVelocity)
    {
        if (rb.velocity.z > 2 || rb.velocity.z < -2  && velocityZ < currentMaxVelocity)
        {
            Debug.Log("avanti");
            // if player presses forward increase velocity in z direction
            velocityZ += Time.deltaTime * acceleration;
        }
        
        if (rb.velocity.x < -1 && velocityX > -currentMaxVelocity)
        { 
            // increase velocity in left direction
            velocityX += Time.deltaTime * acceleration;
        }

        if (rb.velocity.x > 1 && velocityX < currentMaxVelocity)
        {
            // increase velocity in right direction
            velocityX += Time.deltaTime * acceleration;
        }

        // decrease velocityZ
        if (rb.velocity.z < 1 && velocityZ > 0.0f)
        {
            velocityZ -= Time.deltaTime * deceleration;
        }


        // increase velocityX if left is not pressed and velocityX < 0

        if (rb.velocity.x > - 0.5 && velocityX < 0.0f)
        {
            velocityX += Time.deltaTime * deceleration;
        }

        // decrease velocityX if right is not pressed and velocityX > 0
        if (rb.velocity.x < 0.5 && velocityX > 0.0f)

        {
            velocityX += Time.deltaTime * deceleration;
        }
    }

    // handles reset and loocking of velocity
    void LockOrResetVelocity ( float currentMaxVelocity)
    {
        // reset velocityZ
        if (rb.velocity.z ==0 && velocityZ > 0.0f)
        {
            velocityZ = 0.0f;
        }


        // reset velocityX
        if (rb.velocity.x == 0 && velocityX != 0.0f && (velocityX > -0.05f && velocityX < -0.05f))
        {
            velocityX = 0.0f;
        }

        // lock forward
        if (rb.velocity.z > 0 && velocityZ > currentMaxVelocity)
        {
            velocityZ = currentMaxVelocity;
        }

        // decelerate to the maximum walk velocity
        else if (rb.velocity.z > 0 && velocityZ > currentMaxVelocity)
        {
            velocityZ -= Time.deltaTime * deceleration;
            // round to the currentmaxvelocity if whitin offset 
            if (velocityZ > currentMaxVelocity && velocityZ < (currentMaxVelocity + 0.05f))
            {
                velocityZ = currentMaxVelocity;
            }
        }
        // round to the currentmaxvelocity if whitin offset
        else if (rb.velocity.z > 0 && velocityZ < currentMaxVelocity && velocityZ > (currentMaxVelocity - 0.05f))
        {
            velocityZ = currentMaxVelocity;
        }

        // looking left
        if (rb.velocity.x < 0.5 && rb.velocity.z > 0 && velocityX < -currentMaxVelocity)
        {
            velocityX = -currentMaxVelocity;
        }

        // decelerate to the maximum walk velocity
        else if (rb.velocity.x < 0 && velocityX < -currentMaxVelocity)
        {
            velocityX += Time.deltaTime * deceleration;
            // round to the  current max velocity if within offset
            if (velocityX < -currentMaxVelocity && velocityX > (-currentMaxVelocity - 0.05f))
            {
                velocityX = -currentMaxVelocity;
            }
            // round to the  current max velocity if within offset
            else if (rb.velocity.x < 0 && velocityX > -currentMaxVelocity && velocityX < (-currentMaxVelocity + 0.05f))
            {
                velocityX = -currentMaxVelocity;
            }
        }
        // looking right
        if (rb.velocity.x > 0 && rb.velocity.z > 0 && velocityX > currentMaxVelocity)
        {
            velocityX = currentMaxVelocity;
        }

        // decelerate to the maximum walk velocity
        else if (rb.velocity.x > 0 && velocityX > currentMaxVelocity)
        {
            velocityX -= Time.deltaTime * deceleration;
            // round to the  current max velocity if within offset
            if (velocityX > currentMaxVelocity && velocityX < (currentMaxVelocity + 0.05f))
            {
                velocityX = currentMaxVelocity;
            }
            // round to the  current max velocity if within offset
            else if (rb.velocity.x > 0 && velocityX < currentMaxVelocity && velocityX > (-currentMaxVelocity - 0.05f))
            {
                velocityX = currentMaxVelocity;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        // input will be true if the player is pressing on the passed in the key parameter
        // get key input from player

        float currentMaxVelocity = rb.velocity.magnitude;
        // handle change in velocity
        changeVelocity ( currentMaxVelocity);
        LockOrResetVelocity(currentMaxVelocity);

        // set current maxvelocity (min 17:21)

        // set the parameters to our local variable values
        animator.SetFloat(VelocityZHash, velocityZ);
        animator.SetFloat(VelocityXHash, velocityX);
    }
}
