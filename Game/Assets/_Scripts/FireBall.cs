using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : Attack
{
    public GameObject ball;
    private float damage = 10;
    public override float getDamage()
    {
        return damage;
    }

    void Start()
    {
        ball = Instantiate(ball, new Vector3(0, 0, 0), Quaternion.identity);
        ball.tag="FireBall";
        ball.SetActive(false);
        
    }
    public override void attack()
    {

        Vector3 AttackLocation= GameObject.Find("Player").transform.position;
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            ball.SetActive(true);
            ball.GetComponent<bombAction>().setUp(2, AttackLocation, GameObject.Find("Player").transform);
            StartCoroutine(Hide());
        }
        else if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            ball.SetActive(true);
            ball.GetComponent<bombAction>().setUp(3, AttackLocation, GameObject.Find("Player").transform);
            StartCoroutine(Hide());
        }
        else if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            ball.SetActive(true);
            ball.GetComponent<bombAction>().setUp(4, AttackLocation, GameObject.Find("Player").transform);
            StartCoroutine(Hide());
        }
        else if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            ball.SetActive(true);
            ball.GetComponent<bombAction>().setUp(1, AttackLocation, GameObject.Find("Player").transform);
            StartCoroutine(Hide());
        }
    }

    IEnumerator Hide()
    {
        yield return new WaitForSeconds(1f);
        ball.SetActive(false);
    }
}
