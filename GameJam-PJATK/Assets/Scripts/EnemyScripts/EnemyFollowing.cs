using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class EnemyFollowing : MonoBehaviour
{
    [SerializeField] public Transform player;
    [SerializeField] private Transform waypoint1;
    [SerializeField] private Transform waypoint2;
    [SerializeField] private float walkingSpeed = 15;
    [SerializeField] private float jumpCooldown = 4f;


    [HideInInspector] public bool isFocusedOnPlayer = false;

    private Rigidbody rb;
    private Enemy enemy;
    private bool canJump = true;
    private bool isChangingZ = false;

    private Transform destination;
    void Start()
    {
        if (waypoint1 != null && waypoint2 != null)
        {
            destination = waypoint2;
            transform.position = waypoint1.position;
        }
        enemy = GetComponent<Enemy>();
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (waypoint1 != null && waypoint2 != null && !isFocusedOnPlayer)
        {
            ProcessPathWalking();
        }

        if (isFocusedOnPlayer)
        {
            if (transform.position.z == player.position.z)
            {
                Vector3 distanceVecor = player.position - transform.position;
                Vector3 direction = distanceVecor.normalized;
                transform.DOLookAt(new Vector3(player.position.x, transform.position.y, player.position.z), 0.5f);
                if (rb.velocity.x < 5 && enemy.IsGrounded()) rb.AddForce(new Vector3(direction.x, 0, 0)* walkingSpeed, ForceMode.Force);
                if (canJump && enemy.IsGrounded() && distanceVecor.magnitude < 2.5f)
                {
                    canJump = false;
                    enemy.Jump();
                    Invoke(nameof(ResetJumpCooldown), jumpCooldown);
                }
            }
            else
            {
                if(!isChangingZ)
                {
                    isChangingZ = true;
                    transform.DOMoveZ(player.position.z, 1f).OnComplete(() =>
                    {
                        isChangingZ = false;
                    });
                
                }
            }
        }
    }

    void ProcessPathWalking()
    {
        if (enemy.canMove)
        {
            Vector3 distanceVecor = destination.position - transform.position;
            Vector3 direction = distanceVecor.normalized;
            if (distanceVecor.magnitude < 1f)
            {
                if (destination == waypoint1) destination = waypoint2;
                else destination = waypoint1;
            }
            transform.LookAt(destination);
            if (rb.velocity.magnitude < 5 && enemy.IsGrounded()) rb.AddForce(direction * walkingSpeed, ForceMode.Force);

        }
    }

    void ResetJumpCooldown() => canJump = true;
}
