using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DangerZone : MonoBehaviour
{


    public void OnTriggerEnter(Collider collision) {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
        }
        
    }

    public void OnTriggerEnterExit2d(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) ;
           
    }
}
