using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float movementSpeed, jumpForce;

    [SerializeField] private LayerMask ignoreMe;

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

    bool doubleSpeedPower = false;
    bool doubleJumpPower = false;

    void Start()
    {
        collider = GetComponent<Collider>();
        rb = GetComponent<Rigidbody>();
        anim = transform.GetChild(0).GetComponent<Animator>();
        normalJumpForce = jumpForce;
        startingZposition = transform.position.z;

        GameEventSystem.Instance.OnDoubleSpeedAcquire += AcquireDoubleSpeed;
        GameEventSystem.Instance.OnDoubleJumpAcquire += AcquireDoubleJump;

        GameEventSystem.Instance.OnDoubleSpeedGrounded += GetDoubleSpeed;
        GameEventSystem.Instance.OnDoubleSpeedAirborne += GetNominalSpeed;

        GameEventSystem.Instance.CheckpointReached();
        GameEventSystem.Instance.OnPlayerFellButSurvived += BackToCheckpoint;
    }

    public void BackToCheckpoint(GameData data)
    {
        gameObject.transform.position = data.lastCheckpoint;
    }

    public void AcquireDoubleSpeed()
    {
        doubleSpeedPower = true;
    }

    public void AcquireDoubleJump()
    {
        doubleJumpPower = true;
    }

    void Update()
    {
        //bool isgr = Physics.Raycast(transform.position, -Vector3.up, collider.bounds.extents.y + 0.1f);
        //Debug.Log(isgr);
        anim.SetFloat("velocity", rb.velocity.magnitude);
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        movement = x * movementSpeed;

        if (Input.GetButtonDown("Jump"))
        {
            if (!isGrounded && !secondJumpUsed)
            {
                if (doubleJumpPower)
                    jumpForce = -normalJumpForce;
                else
                    jumpForce = normalJumpForce;

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
        isGrounded = Physics.Raycast(transform.position, Vector3.down, collider.bounds.extents.y + 0.1f, ~ignoreMe);
        anim.SetBool("Grounded", isGrounded);
        if (isGrounded)
        {
            secondJumpUsed = false;

            if (doubleSpeedPower)
                GameEventSystem.Instance.DoubleSpeedGrounded();
        }
        else if (doubleSpeedPower)
            GameEventSystem.Instance.DoubleSpeedAirborne();

        rb.velocity = new Vector3(movement, rb.velocity.y, 0);

        if (jump)
        {
            Jump();
            jump = false;
        }
    }

    void Jump()
    {
        anim.SetTrigger("jump");
        rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
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
        /*
        if (collision.gameObject.CompareTag("Ground"))
        {
            //isGrounded = true;
            secondJumpUsed = false;
            //anim.SetBool("Grounded", true);

            if (doubleSpeedPower)
            {
                GameEventSystem.Instance.DoubleSpeedGrounded();
            }
        }
        */
    }

    void OnCollisionExit(Collision collision)
    {
        /*
        if (collision.gameObject.CompareTag("Ground"))
        {
            //isGrounded = false;
            //anim.SetBool("Grounded", false);

            if (doubleSpeedPower)
            {
                GameEventSystem.Instance.DoubleSpeedAirborne();
            }
        }
        */
    }

    public void GetDoubleSpeed(GameData data)
    {
        movementSpeed = 2*data.playerSpeed;
    }

    public void GetNominalSpeed(GameData data)
    {
        movementSpeed = data.playerSpeed;
    }
}
