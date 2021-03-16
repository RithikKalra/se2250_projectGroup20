using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
//update
public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float moveSpeed = 2.0f;
    public Transform movePoint;

    public Transform HealthBar;
    private HealthSystem healthSystem;

    public GameOverScreen GameOverScreen;

    private bool isTurn;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        movePoint.parent = null;

        healthSystem = new HealthSystem(100);

        Transform healthBarTransform = Instantiate(HealthBar, new Vector3(0f, 0.5f), Quaternion.identity);
        HealthBar hb = healthBarTransform.GetComponent<HealthBar>();

        healthBarTransform.transform.parent = GameObject.Find("Player").transform;

        hb.Setup(healthSystem);
    }

    void Update()
    {
        if (healthSystem.GetHealth() <= 0)
        {
            GameOver();
        }
    }

    public bool GetIsTurn()
    {
        return isTurn;
    }

    public void SetIsTurn(bool isTurn)
    {
        this.isTurn = isTurn;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Transform rootT = other.gameObject.transform.root;
        GameObject go = rootT.gameObject;

        //Debug.Log("Collided");

        healthSystem.Damage(10);
    }

    public void GameOver()
    {
        GameOverScreen.Setup();
    }

    public void Move(Action stateChange)
    {
        bool moveComplete = false;
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

        if (GetIsTurn())
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                movePoint.position += new Vector3(1f, 0f, 0f);
                moveComplete = true;
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                movePoint.position += new Vector3(-1f, 0f, 0f);
                moveComplete = true;
            }
            else if (Input.GetKeyDown(KeyCode.W))
            {
                movePoint.position += new Vector3(0f, 1f, 0f);
                moveComplete = true;
            }
            else if (Input.GetKeyDown(KeyCode.S))
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
