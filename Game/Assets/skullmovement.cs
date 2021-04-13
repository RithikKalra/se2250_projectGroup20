using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class skullmovement : EnemyMovement
   
{
    
    private enum State
    {
        Deactivated,
        ChaseTarget,
        Shooting,
    }
    public GameObject parent;
    public PlayerController player;
    private Vector3 TargetLocation;

    private int horizontal = 0;
    private int vertical = 0;

    public int pHorizontal;
    public int nHorizontal;
    public int pVertical;
    public int nVertical;

    public float attackRange;
    public float targetRange;

    private Vector3 playerPos;
    private Vector3 enemyPos;

    private float playerX;
    private float playerY;
    private float skullX;
    private float skullY;


    public GameObject ball;
    private float damage = 10;

    public bool isBoss;

    // Start is called before the first frame update
    void Start()
    {
        Marker = Instantiate(Marker, TargetLocation, Quaternion.identity);
        Marker.SetActive(false);
        ball = Instantiate(ball, new Vector3(0, 0, 0), Quaternion.identity);
        ball.tag = "FireBall";
        ball.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = player.transform.position;
        enemyPos = this.transform.position;

        playerX = player.transform.position.x;
        playerY = player.transform.position.y;

        skullX = this.transform.position.x;
        skullY = this.transform.position.y;
    }

    public override void SelectTarget()
    {/*
        Vector3 AttackLocation = GameObject.Find("Player").transform.position;

        switch (state)
    //I DONT UNDERSTAND WHY STATE DOESNT WORK
        {
            default:
            case State.ChaseTarget:
                if (Vector3.Distance(enemyPos, playerPos) < targetRange)
                {
                    if (Math.Abs(skullX - playerX) > Math.Abs(skullY - playerY))
                    {
                        if ((skullX - playerX) < 0)
                        {
                            TargetLocation = new Vector3(1f, 0f, 0f);
                            horizontal = horizontal + 1;
                        }
                        else
                        {
                            TargetLocation = new Vector3(-1f, 0f, 0f);
                            horizontal = horizontal - 1;
                        }
                    }
                    else if (Math.Abs(skullX - playerX) < Math.Abs(skullY - playerY))
                    {
                        if ((skullY - playerY) < 0)
                        {
                            TargetLocation = new Vector3(0f, 1f, 0f);
                            vertical = vertical + 1;
                        }
                        else
                        {
                            TargetLocation = new Vector3(0f, -1f, 0f);
                            vertical = vertical - 1;
                        }
                    }
                    TargetLocation += parent.transform.position;
                    Marker.transform.position = TargetLocation;
                    Marker.SetActive(true);
                }

                else if (Vector3.Distance(enemyPos, playerPos) < attackRange)
                {
                    state = State.Shooting;
                }
                else { }
                break;
            case State.Shooting:

                if (Vector3.Distance(enemyPos, playerPos) < attackRange)
                {
    //PUT SHOOTING CODE HERE at PLAYER POS
                    ball.setActive(true);
                    ball.GetComponent<bombAction>().setUp(1, AttackLocation, GameObject.Find("Player").transform);
                }
                else if (Vector3.Distance(enemyPos, playerPos) > attackRange)
                {
                    state = State.ChaseTarget;
                }
                else { }
                break;
        }*/
    }
    public override Vector3 getTargetLocation()
    {
        return TargetLocation;
    }

    public override bool getIsBoss()
    {
        return isBoss;
    }
    
}
    
    
    



