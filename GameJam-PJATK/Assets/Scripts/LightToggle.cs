using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LightToggle : MonoBehaviour
{

    [SerializeField] private List<Light> lights;
    [SerializeField] private bool toggle;

    // Start is called before the first frame update
    void Start()
    {
        toggle = false;
        //foreach (Transform tr in transform)
        //{
        //    tra.Add(tr);
        //}

        lights = GetComponentsInChildren<Light>().ToList();
    }

    // Update is called once per frame
    void Update()
    {
        if (toggle)
        {
            foreach(Light tr in lights)
            {
                tr.enabled = true;
            }
        }
        else
        {
            foreach (Light tr in lights)
            {
                tr.enabled = false;
            }
        }
    }
}
