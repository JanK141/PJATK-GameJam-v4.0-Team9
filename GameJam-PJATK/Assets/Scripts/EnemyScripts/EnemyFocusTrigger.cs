using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFocusTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
            transform.parent.GetComponent<EnemyFollowing>().isFocusedOnPlayer = true;
    }
}
