using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallGuy : MonoBehaviour
{
    // Start is called before the first frame update
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameEventSystem.Instance.PlayerFell();
        }
    }
}
