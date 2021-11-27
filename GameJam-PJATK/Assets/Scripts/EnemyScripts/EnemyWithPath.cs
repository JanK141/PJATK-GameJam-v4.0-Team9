using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWithPath : MonoBehaviour
{
    [SerializeField] private List<Transform> waypoints;

    private Enemy enemy;
    private int pathIndex = 1;
    void Start()
    {
        enemy = GetComponent<Enemy>();
        transform.position = waypoints[0].position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (enemy.canMove)
        {
            Vector3 distance = waypoints[pathIndex].position - transform.position;
            Vector3 direction = distance.normalized;
        }
    }
}
