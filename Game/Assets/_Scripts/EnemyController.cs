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
    private EnemyMovement marker;

    public Transform HealthBar;
    public HealthSystem healthSystem;

    public EnemyController enemy;
    public EnemyController slimeEnemy;
    public SlimeMovement slimeMovement;
    public Transform Coin;
    public Transform crystal;
    public Transform heart;

    public TurnController turnController;

    public GameObject Marker;

    public bool isBoss;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        movePoint.parent = null;
        marker = GetComponent<EnemyMovement>();

        Vector3 pos;
        if (isBoss)
        {
            healthSystem = new HealthSystem(50);
            pos = gameObject.transform.position + new Vector3(-0.5f, 1f, 0f);
        }
        else
        {
            healthSystem = new HealthSystem(100);
            pos = gameObject.transform.position + new Vector3(-0.5f, 0.5f, 0f);
        }

        Transform healthBarTransform = Instantiate(HealthBar, pos, Quaternion.identity);
        HealthBar hb = healthBarTransform.GetComponent<HealthBar>();
        healthBarTransform.transform.parent = gameObject.transform;

        hb.Setup(healthSystem);
    }

    void Update()
    {
        if (healthSystem.GetHealth() <= 0)
        {
            Vector3 pos = gameObject.transform.position;

            float x = gameObject.transform.position.x;
            float y = gameObject.transform.position.y;

            Vector3 slimeLocation = new Vector3(x, y, 0);

            if (isBoss)
            {
                for(int i = 0; i < 5; i++)
                {
                    Instantiate(Coin, pos, Quaternion.identity);
                }

                Instantiate(crystal, new Vector3(-24.8f, -9.5f, 0), Quaternion.identity);
                Instantiate(heart, pos, Quaternion.identity);
            }
            else
            {
                Instantiate(Coin, pos, Quaternion.identity);
            }

            Destroy(marker.Marker);
            gameObject.SetActive(false);
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
        PlayerController player = GameObject.Find("Player").GetComponent<PlayerController>();

        if ((other.tag.Equals("Sword"))||(other.tag.Equals("FireBall"))||(other.tag.Equals("FireStorm"))){
            //Transform rootT = other.gameObject.transform.root;
            //GameObject go = rootT.gameObject;
            healthSystem.Damage((int)player.getDamage());
        }

        if (other.tag.Equals("Arrow"))
        {
            Transform rootT = other.gameObject.transform.root;
            GameObject go = rootT.gameObject;
            healthSystem.Damage((int)player.getDamage());
            go.SetActive(false);
        }
    }

    public void Move(Action stateChange)
    {
        bool moveComplete = false;

        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

        if ((Vector3.Distance(transform.position, movePoint.position) == 0f && GetIsTurn()) && (marker.Marker != null))
        {
            if (marker.getIsBoss())
            {
                moveSpeed = 4f;
            }
            marker.SelectTarget();
            movePoint.position = marker.getTargetLocation();
            moveComplete = true;
        }

        if (moveComplete)
        {
            stateChange();
        }
    }
}
