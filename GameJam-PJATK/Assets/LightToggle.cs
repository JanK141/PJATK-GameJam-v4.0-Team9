using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightToggle : MonoBehaviour
{

    [SerializeField] private List<Transform> tra;
    [SerializeField] private bool toggle;

    // Start is called before the first frame update
    void Start()
    {
        toggle = false;
        foreach (Transform tr in transform)
        {
            tra.Add(tr);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (toggle)
        {
            foreach(Transform tr in tra)
            {
                tr.GetComponent<Light>().enabled = true;
            }
        }
        else
        {
            foreach (Transform tr in tra)
            {
                tr.GetComponent<Light>().enabled = false;
            }
        }
    }
}
