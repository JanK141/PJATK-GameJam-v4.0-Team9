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
        HP1.SetActive(false);
        HP2.SetActive(false);
        HP3.SetActive(false);
        HP4.SetActive(false);
        HP5.SetActive(false);

        GameEventSystem.Instance.OnPlayerGetDamage += HPUpdate;
        GameEventSystem.Instance.OnNewGame += NewHP;

        GameEventSystem.Instance.OnPlayerDead += GameOver;
        GameEventSystem.Instance.OnGameWon += GameWon;

        GameEventSystem.Instance.NewGame();
    }

    void NewHP()
    {
        int x = PlayerPrefs.GetInt("HP");
        if (x>0)
        {
            HP1.SetActive(true);
        }

        if (x>1)
        {
            HP2.SetActive(true);
        }

        if (x>2)
        {
            HP3.SetActive(true);
        }

        if (x>3)
        {
            HP4.SetActive(true);
        }

        if (x>4)
        {
            HP5.SetActive(true);
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
