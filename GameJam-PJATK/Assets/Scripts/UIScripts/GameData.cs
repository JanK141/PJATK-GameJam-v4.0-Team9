using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public int playerHP;
    public float playerSpeed;
    public int enemyPatrolSpeed;
    public int enemyChaseSpeed;
    public Vector3 lastCheckpoint;
    public GameObject Player;

    bool doubleSpeedPower;

    public GameData()
    {
        if (PlayerPrefs.HasKey("HP"))
        {
            playerHP = PlayerPrefs.GetInt("HP");
        }
        else
        {
            playerHP = 5;
        }
        
        doubleSpeedPower = false;
    }

    public void DoubleSpeedAcquired()
    {
        doubleSpeedPower = true;
    }

    public void ReachCheckpoint(Vector3 position)
    {
        lastCheckpoint = position;
    }

    public bool PlayerTakesDamage()
    {
        playerHP--;
        if (playerHP<=0)
        {
            return true;
        }
        return false;
    }
}
