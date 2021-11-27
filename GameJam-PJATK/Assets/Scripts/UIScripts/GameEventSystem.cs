using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventSystem : MonoBehaviour
{
    public static GameEventSystem Instance;

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

    public event Action<GameData> OnPlayerGetDamage; //invoked on taking damage
    public event Action OnPlayerDead; //invoke on HP reaching 0 in any way
    public event Action OnPlayerFellButSurvived;  //PlayerMovement needs to subscribe a method to bring Player back to last checkpoint on this Event

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
        if (!data.PlayerTakesDamage()) //if the player survives
        {
            OnPlayerFellButSurvived?.Invoke();
        }
        else
        {
            OnPlayerDead?.Invoke();
        }
    }
}
