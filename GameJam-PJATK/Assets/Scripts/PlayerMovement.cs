using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float movementSpeed, jumpForce;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        if (x != 0)
        {
            rb.velocity = new Vector3(x * movementSpeed, rb.velocity.y);
        }

        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(jumpForce * Vector3.up);
        }
    }
}
