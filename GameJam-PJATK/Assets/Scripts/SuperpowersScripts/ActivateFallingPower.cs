using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateFallingPower : MonoBehaviour
{
    public GameObject camera1;  //kamera podczepiona do gracza


    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("XDD");       
            Destroy(this);
            camera1.transform.Rotate(0, 0, 180);
            GameEventSystem.Instance.MapFlip();

        }
            
    }

   
}
