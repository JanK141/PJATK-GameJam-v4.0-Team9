using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MurzynRolling : MonoBehaviour
{
    [SerializeField] private float value;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(rolling());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator rolling()
    {
        
        while (true)
        {
            transform.Rotate(0, value, 0);
            yield return new WaitForSecondsRealtime(0.009f);
        }
    }
}
