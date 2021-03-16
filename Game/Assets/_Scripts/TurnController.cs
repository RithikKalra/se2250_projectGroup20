using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
//update
public class TurnController : MonoBehaviour
{
    public PlayerController player;
    public EnemyController enemy;

    public State state;

    public enum State
    {
        PlayerTurn,
        EnemyTurn,
    }

    void Start()
    {
        state = State.PlayerTurn;
    }

    // Update is called once per frame
    void Update()
    {
        PerformTurn();
    }

    public void PerformTurn()
    {
        if (state == State.PlayerTurn)
        {
            player.SetIsTurn(true);
            enemy.SetIsTurn(false);
            player.Move(() =>
            {
                state = State.EnemyTurn;
            });
        }
        else if (state == State.EnemyTurn)
        {
            enemy.SetIsTurn(true);
            player.SetIsTurn(false);
            enemy.Move(() =>
            {
                state = State.PlayerTurn;
            });
        }
    }
}
