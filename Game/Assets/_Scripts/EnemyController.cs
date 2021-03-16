using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float moveSpeed = 2.0f;
    public Transform movePoint;

    private bool isTurn;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        movePoint.parent = null;
    }

    public bool GetIsTurn()
    {
        return isTurn;
    }

    public void SetIsTurn(bool isTurn)
    {
        this.isTurn = isTurn;
    }

    public void Move(Action stateChange)
    {
        bool moveComplete = false;
        System.Random random = new System.Random();
        int randomizer = random.Next(1, 5);

        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, movePoint.position) == 0f && GetIsTurn())
        {
            if (randomizer == 1)
            {
                movePoint.position += new Vector3(1f, 0f, 0f);
                moveComplete = true;
            }
            else if (randomizer == 2)
            {
                movePoint.position += new Vector3(-1f, 0f, 0f);
                moveComplete = true;
            }
            else if (randomizer == 3)
            {
                movePoint.position += new Vector3(0f, 1f, 0f);
                moveComplete = true;
            }
            else if (randomizer == 4)
            {
                movePoint.position += new Vector3(0f, -1f, 0f);
                moveComplete = true;
            }
        }

        if (moveComplete)
        {
            stateChange();
        }
    }
}
