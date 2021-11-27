using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIUpdate : MonoBehaviour
{
    public GameObject HP1;
    public GameObject HP2;
    public GameObject HP3;
    public GameObject HP4;
    public GameObject HP5;

    void Start()
    {
        GameEventSystem.Instance.OnPlayerGetDamage += HPUpdate;
    }

    void HPUpdate(GameData data)
    {
        if (data.playerHP==4)
        {
            Destroy(HP5);
        }
        else if (data.playerHP == 3)
        {
            Destroy(HP4);
        }
        else if(data.playerHP == 2)
        {
            Destroy(HP3);
        }
        else if (data.playerHP == 1)
        {
            Destroy(HP2);
        }
        else if (data.playerHP == 0)
        {
            Destroy(HP1);
        }
    }
}
