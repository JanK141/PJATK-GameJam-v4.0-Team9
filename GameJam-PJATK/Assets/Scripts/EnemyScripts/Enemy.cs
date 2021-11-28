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
    [SerializeField] private Animator anim;

    private Rigidbody rb;
    private Collider coll;
    private MeshRenderer mr;
    private float distToGround;

    [HideInInspector] public bool canMove = true;
    void Start()
    {
        coll = GetComponent<Collider>();
        rb = GetComponent<Rigidbody>();
        mr = GetComponent<MeshRenderer>();
        distToGround = coll.bounds.extents.y;
        rb.freezeRotation = true;
    }

    void Update()
    {
        anim.SetFloat("velocity", rb.velocity.magnitude);
        anim.SetBool("Grounded", IsGrounded());
    }


    public bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.05f);
    }

    public void Jump()
    {
        anim.SetTrigger("jump");
        rb.velocity = new Vector3(0, Mathf.Sqrt(-2f * jumpHeight * Physics.gravity.y), 0);
    }

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

            GameEventSystem.Instance.PlayerGetDamage();

            float xPushForce = collisionHorizontalPushForce;
            if (other.transform.position.x > transform.position.x) xPushForce *= -1;
            rb.AddForce(xPushForce, collisionVerticalPushForce, 0, ForceMode.Impulse);
            canMove = false;
            Invoke(nameof(UnStun), stunDuration);
            GetComponent<ParticleSystem>().Play();
            anim.SetTrigger("hit");
        }

        if (other.gameObject.CompareTag("DeathZone"))
        {
            Destroy(gameObject);
        }

        if ((other.gameObject.layer == 7 && gameObject.layer == 6) ||
            (gameObject.layer == 7 && other.gameObject.layer == 6))
        {
            Death();
            other.gameObject.GetComponent<Enemy>().Death();
        }
    }

    

    void UnStun() => canMove = true;

    public void SetAsProjectile()
    {
        gameObject.layer = 7;
        transform.GetChild(1).GetComponent<Collider>().enabled = false;
        GetComponent<EnemyFollowing>().isFocusedOnPlayer = false;
        Invoke(nameof(UnProjectile), 3f);
    }

    void UnProjectile()
    {
        gameObject.layer = 6;
        transform.GetChild(1).GetComponent<Collider>().enabled = true;
    }


}
