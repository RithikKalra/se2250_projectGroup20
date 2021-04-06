using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class bombSlimeMovement : EnemyMovement
{
    public GameObject parent;
    public PlayerController player;
    private Vector3 TargetLocation;
    public bombAction Bomb1;
    public bombAction Bomb2;
    public bombAction Bomb3;
    public bombAction Bomb4;
    public GameObject ex1;
    public GameObject ex2;
    public GameObject ex3;
    public GameObject ex4;

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
    private float bombX;
    private float bombY;

    public int lastDir = 0;

    private int countDown = 4;

    public bool isBoss;

    void Start()
    {
        Marker = Instantiate(Marker, TargetLocation, Quaternion.identity);
        Marker.SetActive(false);

        ex1 = Instantiate(ex1, new Vector3 (0,0,0), Quaternion.identity);

        ex2 = Instantiate(ex2, new Vector3 (0,0,0), Quaternion.identity);

        ex3 = Instantiate(ex3, new Vector3 (0,0,0), Quaternion.identity);

        ex4 = Instantiate(ex4, new Vector3 (0,0,0), Quaternion.identity);

        Bomb1=ex1.GetComponent<bombAction>();
        Bomb2=ex2.GetComponent<bombAction>();
        Bomb3=ex3.GetComponent<bombAction>();
        Bomb4=ex4.GetComponent<bombAction>();

        ex1.SetActive(false);
        ex2.SetActive(false);
        ex3.SetActive(false);
        ex4.SetActive(false);


    }

    void Update()
    {
        playerPos = player.transform.position;
        enemyPos = this.transform.position;

        playerX = player.transform.position.x;
        playerY = player.transform.position.y;

        bombX = this.transform.position.x;
        bombY = this.transform.position.y;
        if(countDown<=0){
            Vector3 bombSpawn=gameObject.transform.position;

            Bomb1.setUp(1, bombSpawn, gameObject.transform);
            Bomb2.setUp(2, bombSpawn, gameObject.transform);
            Bomb3.setUp(3, bombSpawn, gameObject.transform);
            Bomb4.setUp(4, bombSpawn, gameObject.transform);

            ex1.SetActive(true);
            ex1.tag="Bomb";
            ex2.SetActive(true);
            ex2.tag="Bomb";
            ex3.SetActive(true);
            ex3.tag="Bomb";
            ex4.SetActive(true);
            ex4.tag="Bomb";
            gameObject.GetComponent<EnemyController>().healthSystem.Damage(200);
            //gameObject.SetActive(false);
        }
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
            if (Math.Abs(bombX - playerX) > Math.Abs(bombY - playerY))
            {
                if ((bombX - playerX) < 0)
                {
                    TargetLocation = new Vector3(1f, 0f, 0f);
                    horizontal = horizontal + 1;
                }
                else
                {
                    TargetLocation = new Vector3(-1f, 0f, 0f);
                    horizontal = horizontal - 1;
                }
                countDown=countDown-1;
            }
            else if (Math.Abs(bombX - playerX) < Math.Abs(bombY - playerY))
            {
                if ((bombY - playerY) < 0)
                {
                    TargetLocation = new Vector3(0f, 1f, 0f);
                    vertical = vertical + 1;
                }
                else
                {
                    TargetLocation = new Vector3(0f, -1f, 0f);
                    vertical = vertical - 1;
                }
                countDown=countDown-1;
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
