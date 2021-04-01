using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
//update
public class TurnController : MonoBehaviour
{
    public PlayerController player;
    public List<EnemyController> enemies;

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
        player.SetIsTurn(true);

        if (enemies.Count > 0)
        {
            for(int i = 0; i < enemies.Count; i++)
            {
                enemies[i].SetIsTurn(false);
            }
        }

        player.pTurn(() =>
        {
            state = State.EnemyTurn;
        });
    }

    void LateUpdate()
    {
        if (state == State.EnemyTurn && enemies.Count > 0)
        {
            player.SetIsTurn(false);

            for(int i = 0; i < enemies.Count; i++)
            {
                enemies[i].SetIsTurn(true);

                enemies[i].Move(() =>
                {
                    state = State.PlayerTurn;
                });
            }
        }
    }

    public void Add(EnemyController newEnemy)
    {
        enemies.Add(newEnemy);
    }

    public void Remove(EnemyController enemy)
    {
        enemies.Remove(enemy);
    }

    public EnemyController GetElement(int index)
    {
        return enemies[index];
    }
}
