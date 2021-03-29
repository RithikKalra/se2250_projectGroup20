using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
//update
public class PlayerController : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite ninjaSprite;
    public Sprite knightSprite;
    public Sprite wizardSprite;

    public int coinBalance;
    public TMP_Text coinText;

    private Rigidbody2D rb2d;
    public float moveSpeed = 2.0f;
    public bool isJumping = false;
    public bool jumpedLast = false;
    public float jumpSpeed = 15.0f;
    public Transform movePoint;

    public Transform HealthBar;
    private HealthSystem healthSystem;

    public GameOverScreen GameOverScreen;

    private bool isTurn;

    private List<Attack> attackList = new List<Attack>();
    public Attack currentAttack; 
    public Stab stab;
    public Shoot shoot;

    public int lastDir = 0;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        movePoint.parent = null;

        healthSystem = new HealthSystem(100);

        Transform healthBarTransform = Instantiate(HealthBar, new Vector3(0f, 0.5f), Quaternion.identity);
        HealthBar hb = healthBarTransform.GetComponent<HealthBar>();

        healthBarTransform.transform.parent = GameObject.Find("Player").transform;

        hb.Setup(healthSystem);

        currentAttack = shoot;
        attackList.Add(shoot);
        attackList.Add(stab);
    
        if (GameLoader.playerType == 1)
        { 
            spriteRenderer.sprite = knightSprite;
            //Add code unique to the knight
        }
        else if(GameLoader.playerType == 2)
        {
            spriteRenderer.sprite = ninjaSprite;
            //Add code unique to the ninja
        }
        else
        {
            spriteRenderer.sprite = wizardSprite;
            //Add code unique to the wizard
        } 
    }

    void Update()
    {
        coinText.text = "Money: " + coinBalance.ToString() + " Axils";

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
        if(!(other.tag.Equals("Sword")) && !(other.tag.Equals("Coin")) && !(other.tag.Equals("Arrow")))
        {
            healthSystem.Damage(10);
        }

        if(other.tag.Equals("Coin"))
        {
            Transform rootT = other.gameObject.transform.root;
            GameObject go = rootT.gameObject;
            Destroy(go);
            coinBalance += 100;
        }
    }

    public void GameOver()
    {
        GameOverScreen.Setup();
    }

    public void pTurn(Action stateChange)
    {
        bool moveComplete = false;

        if (!isJumping)
        {
            transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, movePoint.position, jumpSpeed * Time.deltaTime);
        }

        CycleAttack();

        if (GetIsTurn())
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                setIsJumping(true);
                switch (lastDir)
                {
                    case 1:
                        movePoint.position += new Vector3(3f, 0f, 0f);
                        break;
                    case 2:
                        movePoint.position += new Vector3(-3f, 0f, 0f);
                        break;
                    case 3:
                        movePoint.position += new Vector3(0f, 3f, 0f);
                        break;
                    case 4:
                        movePoint.position += new Vector3(0f, -3f, 0f);
                        break;
                    default:
                        movePoint.position += new Vector3(3f, 0f, 0f);
                        break;
                }
                moveComplete = true;
                setJumpedLast(true);
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                setIsJumping(false);
                currentAttack.attack();
                moveComplete = true;
            }
            else if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D)) 
            {
                setIsJumping(false);
                if (Input.GetKeyDown(KeyCode.D))
                {
                    movePoint.position += new Vector3(1f, 0f, 0f);
                    setLastDir(1);
                    moveComplete = true;
                }
                else if (Input.GetKeyDown(KeyCode.A))
                {
                    movePoint.position += new Vector3(-1f, 0f, 0f);
                    setLastDir(2);
                    moveComplete = true;
                }
                else if (Input.GetKeyDown(KeyCode.W))
                {
                    movePoint.position += new Vector3(0f, 1f, 0f);
                    setLastDir(3);
                    moveComplete = true;
                }
                else if (Input.GetKeyDown(KeyCode.S))
                {
                    movePoint.position += new Vector3(0f, -1f, 0f);
                    setLastDir(4);
                    moveComplete = true;
                }
                setJumpedLast(false);
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
        if (getJumpedLast())
        {
            return currentAttack.getDamage() * 2;
        }
        else
        {
            return currentAttack.getDamage();
        }
    }

    public void setLastDir(int i)
    {
        this.lastDir = i;
    }

    public void setIsJumping(bool j)
    {
        this.isJumping = j;
    }

    public void setJumpedLast(bool move)
    {
        this.jumpedLast = move;
    }

    public bool getJumpedLast()
    {
        return jumpedLast;
    }
}
