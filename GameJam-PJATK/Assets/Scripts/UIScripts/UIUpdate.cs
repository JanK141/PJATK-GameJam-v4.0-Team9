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
        if (data.playerHP < 5 && HP5!=null)
        {
            Destroy(HP5);
        }
        else if (data.playerHP < 4 && HP4 != null)
        {
            Destroy(HP4);
        }
        else if(data.playerHP < 3 && HP3 != null)
        {
            Destroy(HP3);
        }
        else if (data.playerHP < 2 && HP2 != null)
        {
            Destroy(HP2);
        }
        else if (data.playerHP < 1 && HP1 != null)
        {
            Destroy(HP1);
        }
    }
}
