using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

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

    void Awake()
    {
        collider = GetComponent<Collider>();
        rb = GetComponent<Rigidbody>();
        anim = transform.GetChild(0).GetComponent<Animator>();
        normalJumpForce = jumpForce;
    }

    void Update()
    {
        anim.SetFloat("velocity", rb.velocity.magnitude);
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
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

        transform.LookAt(new Vector3(transform.position.x +rb.velocity.normalized.x*10, transform.position.y, transform.position.z));
    }

    void FixedUpdate()
    {


        rb.velocity = new Vector3(movement, rb.velocity.y);

        if (jump)
        {
            anim.SetTrigger("jump");
            Jump();
            jump = false;
        }
    }

    void Jump()
    {
        rb.AddForce(jumpForce * Vector3.up, ForceMode.Impulse);
        //isGrounded = false;
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
