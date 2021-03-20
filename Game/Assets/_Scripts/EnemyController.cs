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
    public Transform HealthBar;
    private HealthSystem healthSystem;
    public Transform Coin;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        movePoint.parent = null;
        marker= GetComponent<SlimeMovement>();

        healthSystem = new HealthSystem(100);
        Vector3 pos= gameObject.transform.position+new Vector3(-0.5f, 0.5f,0f);
        Transform healthBarTransform = Instantiate(HealthBar, pos, Quaternion.identity);
        HealthBar hb = healthBarTransform.GetComponent<HealthBar>();
        healthBarTransform.transform.parent = gameObject.transform;

        hb.Setup(healthSystem);
       
    }
    void Update(){
        if (healthSystem.GetHealth() <= 0)
        {
            Vector3 pos = gameObject.transform.position;
            Instantiate(Coin, pos, Quaternion.identity);
            marker.Marker.SetActive(false);
            Destroy(gameObject);
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
        if(other.tag.Equals("Sword")){
            Transform rootT = other.gameObject.transform.root;
            GameObject go = rootT.gameObject;
            PlayerController player= GameObject.Find("Player").GetComponent<PlayerController>();
            healthSystem.Damage((int)player.getDamage());
        }
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
