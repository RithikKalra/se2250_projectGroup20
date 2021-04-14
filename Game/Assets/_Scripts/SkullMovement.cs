using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SkullMovement : EnemyMovement
{
    public GameObject ball;
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
    private float skullX;
    private float skullY;

    public bool isBoss;

    void Start()
    {
        ball = Instantiate(ball, new Vector3(0, 0, 0), Quaternion.identity);
        ball.tag="FireBlast";
        ball.SetActive(false);

        Marker = Instantiate(Marker, TargetLocation, Quaternion.identity);
        Marker.SetActive(false);
    }

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
    {
        if(Marker != null)
        {
            Marker.SetActive(false);
        }
    
        System.Random random = new System.Random();
        int randomizer = random.Next(1, 5);

        if(playerX==skullX){
            if(skullY>playerY){
                ball.SetActive(true);
                ball.GetComponent<bombAction>().setUp(4, this.transform.position, this.transform);
                StartCoroutine(Hide());
            }
            else{
                ball.SetActive(true);
                ball.GetComponent<bombAction>().setUp(2, this.transform.position, this.transform);
                StartCoroutine(Hide());
            }

        }
        else if(playerY==skullY){
            if(skullX>playerX){
                ball.SetActive(true);
                ball.GetComponent<bombAction>().setUp(3, this.transform.position, this.transform);
                StartCoroutine(Hide());
            }
            else{
                ball.SetActive(true);
                ball.GetComponent<bombAction>().setUp(1, this.transform.position, this.transform);
                StartCoroutine(Hide());
            }

        }

        else {
            if (Vector3.Distance(playerPos, enemyPos) <= 7f)
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
    }   

    public override Vector3 getTargetLocation()
    {
        return TargetLocation;
    }

    public override bool getIsBoss()
    {
        return isBoss;
    }
    IEnumerator Hide()
    {
        yield return new WaitForSeconds(1f);
        ball.SetActive(false);
    }
}
