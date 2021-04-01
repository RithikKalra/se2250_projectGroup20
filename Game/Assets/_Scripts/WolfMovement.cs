using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WolfMovement : EnemyMovement
{
    public GameObject parent;
    public PlayerController player;
    private Vector3 TargetLocation;

    private int horizontal = 0;
    private int vertical = 0;

    public int pHorizontal;
    public int nHorizontal;
    public int pVertical;
    public int nVertical;

    private Vector3 playerPos;
    private Vector3 enemyPos;

    private float playerX;
    private float playerY;
    private float wolfX;
    private float wolfY;

    public bool isBoss;

    void Start()
    {
        Marker = Instantiate(Marker, TargetLocation, Quaternion.identity);
        Marker.SetActive(false);
    }

    void Update()
    {
        playerPos = player.transform.position;
        enemyPos = this.transform.position;

        playerX = player.transform.position.x;
        playerY = player.transform.position.y;

        wolfX = this.transform.position.x;
        wolfY = this.transform.position.y;
    }

    public override void SelectTarget()
    {
        if(Marker != null)
        {
            Marker.SetActive(false);
        }
    
        System.Random random = new System.Random();
        int randomizer = random.Next(1, 5);


        if (Vector3.Distance(playerPos, enemyPos) <= 7f)
        {
            if (Math.Abs(wolfX - playerX) > Math.Abs(wolfY - playerY))
            {
                if ((wolfX - playerX) < 0)
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
            else if (Math.Abs(wolfX - playerX) < Math.Abs(wolfY - playerY))
            {
                if ((wolfY - playerY) < 0)
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
        }

        else 
        {
            if (randomizer == 1)
            {
                if (horizontal > pHorizontal)
                {
                    TargetLocation = new Vector3(-1f, 0f, 0f);
                    horizontal = horizontal - 1;
                }

                else
                {
                   TargetLocation = new Vector3(1f, 0f, 0f);
                   horizontal = horizontal + 1;
                }
            }

            else if (randomizer == 2)
            {
                if (horizontal < nHorizontal)
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

            else if (randomizer == 3)
            {
                if (vertical > pVertical)
                {
                    TargetLocation = new Vector3(0f, -1f, 0f);
                    vertical = vertical - 1;
                }
                else
                {
                    TargetLocation = new Vector3(0f, 1f, 0f);
                    vertical = vertical + 1;
                }
            }

            else
            {
                if (vertical < nVertical)
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
        }

        TargetLocation+=parent.transform.position;
        Marker.transform.position=TargetLocation;
        Marker.SetActive(true);
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
