using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventSystem : MonoBehaviour
{
    public static GameEventSystem Instance;
    public GameObject UI_canvas;
    public GameObject player;
    
    [SerializeField]
    private GameData data;

    private void Awake()
    {
        //DontDestroyOnLoad(gameObject);

        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            //Destroy(this); jesli nie dziala
        }

        data = new GameData();
    }

    public void SetHP(int x)
    {
        data.playerHP = x;
    }

    //start
    public event Action OnNewGame; //invoked the moment a new game is started

    //damage
    public event Action<GameData> OnPlayerGetDamage; //invoked on taking damage
    public event Action<GameData> OnPlayerFellButSurvived;  //PlayerMovement needs to subscribe a method to bring Player back to last checkpoint on this Event
    public event Action<GameData> OnCheckpointReached;

    //game end
    public event Action OnPlayerDead; //invoke on HP reaching 0 in any way
    public event Action OnGameWon; //invoked when the player reaches the finish

    //superpowers
    public event Action<GameData> OnDoubleSpeedGrounded;
    public event Action<GameData> OnDoubleSpeedAirborne;
    public event Action OnDoubleSpeedAcquire;
    public event Action OnDoubleJumpAcquire;

    public event Action OnMapFlip;
    public void NewGame()
    {
        OnNewGame?.Invoke();
    }

    public void DoubleSpeedSuperPowerAcquired() //this method should be called by the superpower orb on collision
    {
        OnDoubleSpeedAcquire?.Invoke();
        data.DoubleSpeedAcquired();
    }

    public void DoubleJumpSuperPowerAcquired() //this method should be called by the superpower orb on collision
    {
        OnDoubleJumpAcquire?.Invoke();
        data.DoubleJumpAcquired();
    }

    public void DoubleSpeedGrounded()
    {
        OnDoubleSpeedGrounded?.Invoke(data);
    }

    public void DoubleSpeedAirborne()
    {
        OnDoubleSpeedAirborne?.Invoke(data);
    }

    public void CheckpointReached() //this method should be called on collision with the checkpoint
    {
        //Debug.Log("checkpoint saved");
        data.ReachCheckpoint(player.transform.position);
    }

    //this gets called whenever a player takes damage
    public void PlayerGetDamage()
    {
        bool DED = data.PlayerTakesDamage(); //DED if the damage kills the player
        OnPlayerGetDamage?.Invoke(data);

        if (DED)
        {
            OnPlayerDead?.Invoke();
        }
    }

    //this gets called, when a player falls down a hole
    public void PlayerFell()
    {
        PlayerGetDamage();
        if (data.playerHP>0) //if the player survives (damage already dealt)
        {
            OnPlayerFellButSurvived?.Invoke(data);
        }
    }

    //this should be called from the Finish object, when the Player reaches it
    public void GameWon()
    {
        OnGameWon?.Invoke();
    }

    public void MapFlip()
    {
        OnMapFlip?.Invoke();
    }
}
