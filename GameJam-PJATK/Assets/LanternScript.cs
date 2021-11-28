using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LanternScript : MonoBehaviour
{
    [SerializeField] private List<Light> lights;
    [SerializeField] private bool toggle;

    // Start is called before the first frame update
    void Start()
    {
        toggle = false;
       
        lights = GetComponentsInChildren<Light>().ToList();
    }

    // Update is called once per frame
    void Update()
    {
        //if (toggle)
        //{
        //    foreach (Light tr in lights)
        //    {
        //        tr.enabled = true;
        //    }
        //}
        //else
        //{
        //    foreach (Light tr in lights)
        //    {
        //        tr.enabled = false;
        //    }
        //}
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            GameEventSystem.Instance.CheckpointReached();

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
