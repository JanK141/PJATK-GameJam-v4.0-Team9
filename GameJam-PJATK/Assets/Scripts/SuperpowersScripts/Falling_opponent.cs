using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling_opponent : MonoBehaviour
{
    public Rigidbody ridigbody;
    void Start()
    {
        GameEventSystem.Instance.OnMapFlip += fall;

    }

    public void fall()
    {
        ridigbody = GetComponent<Rigidbody>(); ;
        ridigbody.useGravity = false;
        ridigbody.AddForce(0, 35f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
