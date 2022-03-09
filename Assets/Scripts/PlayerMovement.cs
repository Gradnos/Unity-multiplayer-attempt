using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Rigidbody))]
public class PlayerMovement : NetworkBehaviour
{

    public float speed = 12;
    public float airMoveMultiplier;
    public float jumpHeight;

    public MouseLook headCamera;
    public Transform orientation;

    public float addedGravityOnFallValue = -9.81f;
    public float apexAddedGravityValue = -2f;
    float addedGravity;


    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    float x;

    Vector3 moveDirection;
    Vector3 moveDistance;
    Vector3 slopeMoveDirection;
    Vector3 slopeHitMoveDistance;
    Rigidbody myRigidBody;
    Vector3 velocity;
    bool isGrounded;


    RaycastHit slopeHit;

    private bool OnSlope()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out slopeHit, 3f))
        {
            if (slopeHit.normal != Vector3.up)
            {
                return true;
            }
        }
        return false;
    }


    void Start()
    {
        myRigidBody = GetComponent<Rigidbody>();
    }

    public void Update()
    {
        headCamera.setLocalPlayer(isLocalPlayer);
        if(isLocalPlayer)
        {  
            isGrounded = Physics.CheckSphere(groundCheck.position , groundDistance, groundMask);

            

            float x = Input.GetAxisRaw("Horizontal");
            float z = Input.GetAxisRaw("Vertical");

            moveDirection = (orientation.right * x + orientation.forward * z).normalized;
            moveDistance = moveDirection * speed;


            if (Input.GetButtonDown("Jump") & isGrounded)
            {
                myRigidBody.velocity = new Vector3(myRigidBody.velocity.x, Mathf.Sqrt(jumpHeight * -2f * Physics.gravity.y) ,myRigidBody.velocity.z) ;
            }

            if (!isGrounded)
            {
                myRigidBody.velocity = new Vector3(myRigidBody.velocity.x, myRigidBody.velocity.y + addedGravity * Time.deltaTime, myRigidBody.velocity.z);
            }


                       
             if (!isGrounded && myRigidBody.velocity.y < 1f  && myRigidBody.velocity.y > 0f)
            {
               // addedGravity = apexAddedGravityValue;
            }
            else if (!isGrounded && myRigidBody.velocity.y < 0)
            {
              // addedGravity = addedGravityOnFallValue;
            }
            else
            {
                addedGravity = 0;
            }

            slopeMoveDirection = Vector3.ProjectOnPlane(moveDirection, slopeHit.normal).normalized;
            slopeHitMoveDistance = slopeMoveDirection * speed;
        }
    }

    void FixedUpdate()
    {

        if (isGrounded && !OnSlope())
        {
        myRigidBody.velocity = new Vector3 (moveDistance.x, myRigidBody.velocity.y, moveDistance.z);
        }
        else if(isGrounded && OnSlope()  && !Input.GetButton("Jump"))
        {
        myRigidBody.velocity = slopeHitMoveDistance;
        }
        else if(!isGrounded)
        {
            myRigidBody.velocity = new Vector3 (moveDistance.x * airMoveMultiplier, myRigidBody.velocity.y, moveDistance.z * airMoveMultiplier);
        }
    }
}
