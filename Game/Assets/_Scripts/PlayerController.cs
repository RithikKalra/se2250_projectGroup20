using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
    public GameObject hpIncrease;

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

    public bool hasCrystal = false;
    public bool hasKey = false;
    public Sprite crystal;
    public Sprite key;
    public Image itemHolder;

    private List<Attack> attackList = new List<Attack>();
    public Attack currentAttack; 
    public Stab stab;
    public Shoot shoot;
    public Slash slash;
    public FireBall fireBall;
    public FireStorm fireStorm;

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

        
        
        attackList.Add(fireBall);
        attackList.Add(fireStorm);
    
        if (GameLoader.playerType == 1)
        { 
            spriteRenderer.sprite = knightSprite;
            attackList.Add(stab);
            attackList.Add(slash);
            currentAttack = stab;
        }
        else if(GameLoader.playerType == 2)
        {
            spriteRenderer.sprite = ninjaSprite;
            attackList.Add(shoot);
            currentAttack = shoot;
        }
        else
        {
            spriteRenderer.sprite = wizardSprite;
            attackList.Add(fireBall);
            attackList.Add(fireStorm);
            currentAttack = fireBall;
        }

        hpIncrease.gameObject.SetActive(false);
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

        if(other.tag.Equals("Slime")||other.tag.Equals("FireStorm"))
        {         
            healthSystem.Damage(10);
        }
        if (other.tag.Equals("BossSlime")||other.tag.Equals("Bomb"))
        {
            healthSystem.Damage(50);
        }
        if (other.tag.Equals("TutTerry") && TutTerryController.isEnemy || other.tag.Equals("Wolf"))
        {
            healthSystem.Damage(20);
        }
        if (other.tag.Equals("Coin"))
        {
            Transform rootT = other.gameObject.transform.root;
            GameObject go = rootT.gameObject;
            Destroy(go);
            coinBalance += 100;
        }
        if (other.tag.Equals("CrystalDrop"))
        {
            Transform rootT = other.gameObject.transform.root;
            GameObject go = rootT.gameObject;
            Destroy(go);
            hasCrystal = true;
            itemHolder.sprite = crystal;
        }
        if (other.tag.Equals("Heart"))
        {
            Transform rootT = other.gameObject.transform.root;
            GameObject go = rootT.gameObject;
            Destroy(go);

            hpIncrease.gameObject.SetActive(true);
            healthSystem.SetHealthMax(healthSystem.GetHealthMax() + 50);
            healthSystem.SetHealth(healthSystem.GetHealthMax());
            Invoke("ClearText", 2);
        }
        if (other.tag.Equals("Smasher"))
        {
            healthSystem.Damage(50);
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

    public void HealPlayer()
    {
        healthSystem.SetHealth(healthSystem.GetHealth() + 100);

        if(healthSystem.GetHealth() > healthSystem.GetHealthMax())
        {
            healthSystem.SetHealth(healthSystem.GetHealthMax());
        }
    }

    public void ClearText()
    {
        hpIncrease.gameObject.SetActive(false);
    }
}
