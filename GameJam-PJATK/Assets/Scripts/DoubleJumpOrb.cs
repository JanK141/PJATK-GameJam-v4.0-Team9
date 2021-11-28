using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJumpOrb : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameEventSystem.Instance.DoubleJumpSuperPowerAcquired();
            Destroy(gameObject);
        }
    }
}
