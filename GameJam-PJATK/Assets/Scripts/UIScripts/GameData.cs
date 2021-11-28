using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public int playerHP;
    public float playerSpeed;
    public float enemyPatrolSpeed;
    public int enemyChaseSpeed;
    public Vector3 lastCheckpoint;
    public GameObject Player;

    public bool doubleSpeedPower;
    public bool doubleJumpPower;

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

        playerSpeed = 7f;
        enemyPatrolSpeed = 15f;
        
        doubleSpeedPower = false;
        doubleJumpPower = false;
    }

    public void DoubleSpeedAcquired()
    {
        doubleSpeedPower = true;
    }

    public void DoubleJumpAcquired()
    {
        doubleJumpPower = true;
    }

    public void ReachCheckpoint(Vector3 position)
    {
        lastCheckpoint = position;
        //Debug.Log("checkpoint position saved in data");
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
