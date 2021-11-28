using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class EnemyWithPath : MonoBehaviour
{
    [SerializeField] private Transform waypoint1;
    [SerializeField] private Transform waypoint2;
    [SerializeField] private float walkingSpeed = 15;

    private Rigidbody rb;
    private Enemy enemy;
    private bool isJumpInvoked = false;

    private Transform destination;
    void Start()
    {
        destination = waypoint2;
        enemy = GetComponent<Enemy>();
        rb = GetComponent<Rigidbody>();
        transform.position = waypoint1.position;

        GameEventSystem.Instance.OnDoubleSpeedGrounded += GetNominalSpeed;
        GameEventSystem.Instance.OnDoubleSpeedAirborne += GetDoubleSpeed;
    }
    
    public void GetDoubleSpeed(GameData data)
    {
        walkingSpeed = 2 * data.enemyPatrolSpeed;
    }

    public void GetNominalSpeed(GameData data)
    {
        walkingSpeed = data.enemyPatrolSpeed;
    }

    void FixedUpdate()
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
            transform.DOLookAt(destination.position, 0.5f);
            if(rb.velocity.magnitude<5 && enemy.IsGrounded()) rb.AddForce(direction*walkingSpeed, ForceMode.Force);

            if(!isJumpInvoked)Invoke(nameof(JumpInvoke), Random.Range(2,5));
            isJumpInvoked = true;
        }
    }

    void JumpInvoke()
    {
        Invoke(nameof(ResetJump), 0.5f);
        if(enemy.IsGrounded())enemy.Jump();
    }

    void ResetJump() => isJumpInvoked = false;
}
