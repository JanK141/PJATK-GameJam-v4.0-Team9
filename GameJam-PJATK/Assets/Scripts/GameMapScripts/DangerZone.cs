using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerZone : MonoBehaviour
{


    public void OnTriggerEnter2d(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player")) ;
            
            
    }

    public void OnTriggerEnterExit2d(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player")) ;
            
    }
}
