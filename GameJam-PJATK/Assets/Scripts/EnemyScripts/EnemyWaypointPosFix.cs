using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaypointPosFix : MonoBehaviour
{
    [SerializeField] [Tooltip("Enemy to wich this point should correct its y position value")] private Transform enemy;

    void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x, enemy.position.y, transform.position.z);
    }

    void Update()
    {
        if(enemy==null) Destroy(gameObject);
    }
}
