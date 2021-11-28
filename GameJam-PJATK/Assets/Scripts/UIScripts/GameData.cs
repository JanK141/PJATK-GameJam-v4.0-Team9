using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData
{
    public int playerHP;
    public int playerSpeed;
    public int enemyPatrolSpeed;
    public int enemyChaseSpeed;
    public Vector3 lastCheckpoint;
    public GameObject Player;


    public GameData()
    {
        playerHP = 5;
    }

    public void ReachCheckpoint()
    {
        lastCheckpoint = Player.transform.position;
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
