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
        rb = GetComponent<Rigidbody>();
        normalJumpForce = jumpForce;
        startingZposition = transform.position.z;
    }

    void Update()
    {
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
        rb.AddForce(jumpForce * Vector3.up, ForceMode.Impulse);
        isGrounded = false;
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
        }
    }
}
