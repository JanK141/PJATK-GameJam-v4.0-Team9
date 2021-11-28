using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float movementSpeed, jumpForce;

    Rigidbody rb;
    private Animator anim;
    private Collider collider;
    float movement = 0f;
    bool isGrounded = true;
    bool jump = false;
    bool secondJumpUsed = false;
    float normalJumpForce;
    float startingZposition;
    float laneWidth = 1f;
    int currentLane = 0;

    void Awake()
    {
        collider = GetComponent<Collider>();
        rb = GetComponent<Rigidbody>();
        anim = transform.GetChild(0).GetComponent<Animator>();
        normalJumpForce = jumpForce;
        startingZposition = transform.position.z;
    }

    void Update()
    {
        anim.SetFloat("velocity", rb.velocity.magnitude);
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        movement = x * movementSpeed;

        if (Input.GetButtonDown("Jump"))
        {
            if (!isGrounded && !secondJumpUsed)
            {
                jumpForce = normalJumpForce / 2;
                jump = true;
                secondJumpUsed = true;
            }

            if (isGrounded)
            {
                jumpForce = normalJumpForce;
                jump = true;
            }
        }

        transform.LookAt(new Vector3(transform.position.x + rb.velocity.normalized.x *10, transform.position.y, transform.position.z));

        ChangeLane(z);
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector3(movement, rb.velocity.y);

        if (jump)
        {
            Jump();
            jump = false;
        }
    }

    void Jump()
    {
        anim.SetTrigger("jump");
        rb.AddForce(jumpForce * Vector3.up, ForceMode.Impulse);
        //isGrounded = false;
    }

    void ChangeLane(float z)
    {
        if (z != 0)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (currentLane < 1)
                {
                    currentLane++;
                    float newZposition = startingZposition + laneWidth * currentLane;
                    transform.DOLocalMoveZ(newZposition, 0.5f);
                }
            }
            else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (currentLane > -1)
                {
                    currentLane--;
                    float newZposition = startingZposition + laneWidth * currentLane;
                    transform.DOLocalMoveZ(newZposition, 0.5f);
                }
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            secondJumpUsed = false;
            anim.SetBool("Grounded", true);
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
            anim.SetBool("Grounded", false);
        }
    }
}
