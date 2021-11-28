using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventSystem : MonoBehaviour
{
    public static GameEventSystem Instance;
    public GameObject UI_canvas;
    
    [SerializeField]
    private GameData data;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        data = new GameData();
    }

    public event Action<GameData> OnNewGame; //invoked the moment a new game is started

    public event Action<GameData> OnPlayerGetDamage; //invoked on taking damage
    public event Action OnPlayerDead; //invoke on HP reaching 0 in any way
    public event Action OnPlayerFellButSurvived;  //PlayerMovement needs to subscribe a method to bring Player back to last checkpoint on this Event

    public event Action OnGameWon; //invoked when the player reaches the finish

    public void NewGame(GameData data)
    {
        Time.timeScale = 1;
        OnNewGame?.Invoke(data);
    }

    //this gets called whenever a player takes damage
    public void PlayerGetDamage()
    {
        bool DED = data.PlayerTakesDamage(); //DED if the damage kills the player
        OnPlayerGetDamage?.Invoke(data);

        if (DED)
        {
            OnPlayerDead?.Invoke();
            //Time.timeScale = 0;
        }
    }

    //this gets called, when a player falls down a hole
    public void PlayerFell()
    {
        if (!data.PlayerTakesDamage()) //if the player survives
        {
            OnPlayerFellButSurvived?.Invoke();
        }
        else
        {
            OnPlayerDead?.Invoke();
        }
    }

    //this should be called from the Finish object, when the Player reaches it
    public void GameWon()
    {
        OnGameWon?.Invoke();
        //Time.timeScale = 0;
    }
}
