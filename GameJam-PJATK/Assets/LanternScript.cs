using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LanternScript : MonoBehaviour
{
    [SerializeField] private List<Light> lights;
    [SerializeField] private bool toggle;

    //LINE 30 EXCEPTION
    // Start is called before the first frame update
    void Start()
    {
        toggle = false;
       
        lights = GetComponentsInChildren<Light>().ToList();

        foreach (Light lt in lights)
        {
            lt.enabled = false;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            GameEventSystem.Instance.CheckpointReached();  //KULA DAJE NULLA

            this.toggle = true;

            lightUpLanterns(toggle);
        }
    }

    private void lightUpLanterns(bool toggle)
    {
        if (toggle)
        {
            foreach (Light lt in lights)
            {
                lt.enabled = true;
            }
        }
    }

 
}
