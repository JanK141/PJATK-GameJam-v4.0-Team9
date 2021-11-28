using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Camera_180 : MonoBehaviour
{
    public GameObject camera;
    void Start()
    {
        camera.transform.Rotate(0, 0, 180);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
