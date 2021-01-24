using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private float speed = 700f;
    private bool groundedPlayer;
    private Vector3 playerVelocity;
    private float jumpHeight = 2.0f;
    private float rotationSpeed = 5.0f;
    private float gravityMultiplier = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //rotate camera
        transform.eulerAngles += new Vector3(Input.GetAxis("Mouse Y") * rotationSpeed * -1f, Input.GetAxis("Mouse X") * rotationSpeed, 0);

        Debug.Log(controller.isGrounded);
        groundedPlayer = controller.isGrounded;


        Vector3 playerVelocity = transform.forward * Input.GetAxis("Vertical") + transform.right * Input.GetAxis("Horizontal");
        playerVelocity *= speed;
        controller.SimpleMove(playerVelocity * Time.deltaTime);

        if (groundedPlayer)
        {

            /*if (Input.GetButtonDown("Crouch")) // Added a new axes called crouch with left shift
            {
                speed /= 3;
                jumpHeight /= 1.5f;
                transform.localScale *= 0.5f;

            }
            if (Input.GetButtonUp("Crouch"))
            {
                speed *= 3;
                jumpHeight *= 1.5f;
                transform.localScale = transform.localScale / 0.5f;

            }*/

            if (groundedPlayer && playerVelocity.y<0)
            {
                playerVelocity.y = 0f;
            }

            // Changes the height position of the player
            if (Input.GetButtonDown("Jump") && groundedPlayer)
            {
                //  playerVelocity.y =Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
                playerVelocity.y = jumpHeight;
                Debug.Log("Jump");
            }
        }
        else
        {
            playerVelocity.y += Physics.gravity.y * gravityMultiplier;

        }
       
    }
}
