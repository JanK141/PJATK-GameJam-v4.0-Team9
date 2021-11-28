using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleSpeedOrb : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameEventSystem.Instance.DoubleSpeedSuperPowerAcquired();
            Destroy(gameObject);
        }
    }
}
