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

    public GameObject gameOverCanvas;
    public GameObject gameWonCanvas;

    void Start()
    {
        GameEventSystem.Instance.OnPlayerGetDamage += HPUpdate;
        GameEventSystem.Instance.OnNewGame += NewHP;

        GameEventSystem.Instance.OnPlayerDead += GameOver;
        GameEventSystem.Instance.OnGameWon += GameWon;
    }

    void NewHP(GameData data)
    {
        if (HP1==null)
        {
            Instantiate(HP1);
        }

        if (HP2==null && data.playerHP>1)
        {
            Instantiate(HP2);
        }

        if (HP2 == null && data.playerHP > 2)
        {
            Instantiate(HP3);
        }

        if (HP2 == null && data.playerHP > 3)
        {
            Instantiate(HP4);
        }

        if (HP2 == null && data.playerHP > 4)
        {
            Instantiate(HP5);
        }
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

    public void GameOver()
    {
        gameObject.SetActive(false);
        gameOverCanvas.SetActive(true);
    }

    public void GameWon()
    {
        gameObject.SetActive(false);
        gameWonCanvas.SetActive(true);
    }
}
