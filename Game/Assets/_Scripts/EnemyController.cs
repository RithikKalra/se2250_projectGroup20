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
    private SlimeMovement marker;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        movePoint.parent = null;
        marker= GetComponent<SlimeMovement>();
       
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
        

        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);
        if (Vector3.Distance(transform.position, movePoint.position) == 0f && GetIsTurn())
        {
            marker.SelectTarget();
            movePoint.position=marker.getTargetLocation();
            moveComplete=true;
        }

        

        if (moveComplete)
        {
            stateChange();
            
        }
    }
}
