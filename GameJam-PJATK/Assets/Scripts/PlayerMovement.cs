using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float movementSpeed, jumpForce;

    Rigidbody rb;
    float movement = 0f;
    bool isGrounded = true;
    bool jump = false;
    bool secondJumpUsed = false;
    float normalJumpForce;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        normalJumpForce = jumpForce;
    }

    void Update()
    {
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
        rb.AddForce(jumpForce * Vector3.up, ForceMode.Impulse);
        isGrounded = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            secondJumpUsed = false;
        }
    }
}
