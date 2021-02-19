using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{

    Rigidbody rb;
    private float timer = 0;
    [SerializeField] private float walkSpeed = 0.55f;
    [SerializeField] private float runSpeed = 0.4f;
    private bool canLand = false;
    public ECM.Components.CharacterMovement characterMovement;


    public AK.Wwise.Event footStep;
    public AK.Wwise.Event landing;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Movement();
        Landing();
    }

    private void Movement()
    {
        //Running
        if (rb.velocity.magnitude > 10f && characterMovement.isGrounded)
        {
            FootstepTimer(runSpeed);
        }
        //Walking
        else if (rb.velocity.magnitude > 1f && characterMovement.isGrounded)
        {
            FootstepTimer(walkSpeed);
        }
    }

    private void Landing()
    {
        //Don't trigger at start.
        if(Input.GetButton("Jump"))
        {
            canLand = true;
        }
        //Make a sound on landing.
        if(canLand)
        {
            if (!characterMovement.wasGrounded && characterMovement.isGrounded)
            {
                landing.Post(gameObject);
            }
        }

    }

    private void FootstepTimer(float speed)
    {
        if (timer > speed)
        {
            footStep.Post(gameObject);
            timer = 0.0f;
        }

        timer += Time.deltaTime;
    }
}
