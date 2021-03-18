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

    private List<Attack> attackList = new List<Attack>();
    public Attack currentAttack; 
    public Stab stab;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        movePoint.parent = null;

        healthSystem = new HealthSystem(100);

        Transform healthBarTransform = Instantiate(HealthBar, new Vector3(0f, 0.5f), Quaternion.identity);
        HealthBar hb = healthBarTransform.GetComponent<HealthBar>();

        healthBarTransform.transform.parent = GameObject.Find("Player").transform;

        hb.Setup(healthSystem);
        currentAttack=stab;
        attackList.Add(stab);
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
        if(!(other.tag.Equals("Sword"))){
            Transform rootT = other.gameObject.transform.root;
            GameObject go = rootT.gameObject;
            healthSystem.Damage(10);
        }
    }

    public void GameOver()
    {
        GameOverScreen.Setup();
    }

    public void pTurn(Action stateChange)
    {
        bool moveComplete = false;
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);
        CycleAttack();
        if (GetIsTurn())
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow) ) {
                currentAttack.attack();
                moveComplete = true;
            }
            else if (Input.GetKeyDown(KeyCode.D))
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
    public void CycleAttack()
    {
        int index = attackList.IndexOf(currentAttack);
        Attack[] seekAttack = attackList.ToArray();
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(index<seekAttack.Length-1){
                currentAttack=seekAttack[index+1];
            }
            else{
                currentAttack=seekAttack[0];
            }
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if(index==0){
                currentAttack=seekAttack[seekAttack.Length-1];
            }
            else{
                currentAttack=seekAttack[index-1];
            }
        }
    }
    public float getDamage()
    {
       return currentAttack.getDamage();
    }
}
