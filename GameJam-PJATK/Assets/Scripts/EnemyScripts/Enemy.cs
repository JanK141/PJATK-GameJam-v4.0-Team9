using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float deathUpLunchForce = 10f;
    [SerializeField] [Tooltip("How long death animations is")] private float timeToDie = 2f;
    [SerializeField] [Tooltip("Horizontal push force in collision with player")] private float collisionHorizontalPushForce = 10f;
    [SerializeField] [Tooltip("Vertical push force in collision with player")] private float collisionVerticalPushForce = 10f;
    [SerializeField] [Tooltip("For how long enemy is stunned after collision with player")] private float stunDuration = 3f;
    [SerializeField] private float jumpHeight = 4f;

    private Rigidbody rb;
    private Collider coll;
    private MeshRenderer mr;
    private float distToGround;
    [SerializeField] private Transform player;

    [HideInInspector] public bool canMove = true;
    void Start()
    {
        coll = GetComponent<Collider>();
        rb = GetComponent<Rigidbody>();
        mr = GetComponent<MeshRenderer>();
        distToGround = coll.bounds.extents.y;
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        /*if (canMove)
        {
            Vector3 directionToPlayer = (player.position - transform.position).normalized;
            rb.AddForce(directionToPlayer*1000*Time.deltaTime);
        }*/
    }

    public bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
    }

    public void Jump() => rb.velocity = new Vector3(0, Mathf.Sqrt(-2f * jumpHeight * Physics.gravity.y), 0);

    public void Death()
    {
        rb.freezeRotation = false;
        rb.AddForce(Vector3.up * deathUpLunchForce + new Vector3(Random.Range(-10,-10), 0, Random.Range(-10,-10)), ForceMode.Impulse);
        rb.AddTorque(Random.Range(-10, -10), Random.Range(-10, -10), Random.Range(-10, -10), ForceMode.Impulse);
        coll.enabled = false;
        mr.material.DOFade(0, timeToDie).OnComplete(() => Destroy(gameObject));
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            //TODO Obra�enia dla gracza

            float xPushForce = collisionHorizontalPushForce;
            if (other.transform.position.x > transform.position.x) xPushForce *= -1;
            rb.AddForce(xPushForce, collisionVerticalPushForce, 0, ForceMode.Impulse);
            canMove = false;
            Invoke(nameof(UnStun), stunDuration);
        }
    }

    void UnStun() => canMove = true;


}
