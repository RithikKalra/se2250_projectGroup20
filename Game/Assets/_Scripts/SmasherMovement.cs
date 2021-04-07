using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SmasherMovement : EnemyMovement
{
    public GameObject parent;
    private Vector3 TargetLocation;

    private int horizontal = 0;
    private int vertical = 0;
    public int pHorizontal;
    public int nHorizontal;
    public int pVertical;
    public int nVertical;

    public bool isBoss = false;

    private float moveDistance = 1f;

    public int counter = 0;

    public GameObject topLeft;
    public GameObject topMiddle;
    public GameObject topRight;
    public GameObject bottomLeft;
    public GameObject bottomMiddle;
    public GameObject bottomRight;
    public GameObject centerLeft;
    public GameObject centerRight;

    void Start()
    {
        Marker = Instantiate(Marker, TargetLocation, Quaternion.identity);
        Marker.SetActive(false);

        if (isBoss)
        {
            moveDistance = 2f;
        }

        topLeft = Instantiate(topLeft, new Vector3(0, 0, 0), Quaternion.identity);
        topLeft.SetActive(false);

        topMiddle = Instantiate(topMiddle, new Vector3(0, 0, 0), Quaternion.identity);
        topMiddle.SetActive(false);

        topRight = Instantiate(topRight, new Vector3(0, 0, 0), Quaternion.identity);
        topRight.SetActive(false);

        bottomLeft = Instantiate(bottomLeft, new Vector3(0, 0, 0), Quaternion.identity);
        bottomLeft.SetActive(false);

        bottomMiddle = Instantiate(bottomMiddle, new Vector3(0, 0, 0), Quaternion.identity);
        bottomMiddle.SetActive(false);

        bottomRight = Instantiate(bottomRight, new Vector3(0, 0, 0), Quaternion.identity);
        bottomRight.SetActive(false);

        centerLeft = Instantiate(centerLeft, new Vector3(0, 0, 0), Quaternion.identity);
        centerLeft.SetActive(false);

        centerRight = Instantiate(centerRight, new Vector3(0, 0, 0), Quaternion.identity);
        centerRight.SetActive(false);
    }

    void LateUpdate()
    {
        if (counter <= 3)
        {
            parent.SetActive(true);
        }
    }

    public override void SelectTarget()
    {
        if (Marker != null)
        {
            Marker.SetActive(false);
        }

        if (counter == 3)
        {
            Attack();
        }

        if (!(parent.activeSelf))
        {
            Debug.Log("Spawn Stuff");
            counter = 0;
        }

        System.Random random = new System.Random();
        int randomizer = random.Next(1, 5);

        if (randomizer == 1)
        {
            if (horizontal > pHorizontal)
            {
                TargetLocation = new Vector3(-(moveDistance), 0f, 0f);
                horizontal = horizontal - (int)(moveDistance);
            }
            else
            {
                TargetLocation = new Vector3((moveDistance), 0f, 0f);
                horizontal = horizontal + (int)(moveDistance);
            }
        }

        else if (randomizer == 2)
        {
            if (horizontal < nHorizontal)
            {
                TargetLocation = new Vector3((moveDistance), 0f, 0f);
                horizontal = horizontal + (int)(moveDistance);
            }
            else
            {
                TargetLocation = new Vector3(-(moveDistance), 0f, 0f);
                horizontal = horizontal - (int)(moveDistance);
            }
        }

        else if (randomizer == 3)
        {
            if (vertical > pVertical)
            {
                TargetLocation = new Vector3(0f, -(moveDistance), 0f);
                vertical = vertical - (int)(moveDistance);
            }
            else
            {
                TargetLocation = new Vector3(0f, (moveDistance), 0f);
                vertical = vertical + (int)(moveDistance);
            }
        }

        else
        {
            if (vertical < nVertical)
            {
                TargetLocation = new Vector3(0f, (moveDistance), 0f);
                vertical = vertical + (int)(moveDistance);
            }
            else
            {
                TargetLocation = new Vector3(0f, -(moveDistance), 0f);
                vertical = vertical - (int)(moveDistance);
            }
        }

        TargetLocation += parent.transform.position;
        Marker.transform.position = TargetLocation;

        Marker.SetActive(true);
        counter++;
    }

    public void Attack()
    {
        parent.SetActive(false);
        counter = 0;
        LateUpdate();

        Vector3 AttackLocation = GameObject.Find("Smasher").transform.position;

        topLeft.transform.position = (AttackLocation + new Vector3(-1f, 1f, 0));
        topLeft.SetActive(true);
        StartCoroutine(Hide());

        topMiddle.transform.position = (AttackLocation + new Vector3(0, 1f, 0));
        topMiddle.SetActive(true);
        StartCoroutine(Hide());

        topRight.transform.position = (AttackLocation + new Vector3(1f, 1f, 0));
        topRight.SetActive(true);
        StartCoroutine(Hide());

        bottomLeft.transform.position = (AttackLocation + new Vector3(-1f, -1f, 0));
        bottomLeft.SetActive(true);
        StartCoroutine(Hide());

        bottomMiddle.transform.position = (AttackLocation + new Vector3(0, -1f, 0));
        bottomMiddle.SetActive(true);
        StartCoroutine(Hide());

        bottomRight.transform.position = (AttackLocation + new Vector3(1f, -1f, 0));
        bottomRight.SetActive(true);
        StartCoroutine(Hide());

        centerLeft.transform.position = (AttackLocation + new Vector3(-1f, 0, 0));
        centerLeft.SetActive(true);
        StartCoroutine(Hide());

        centerRight.transform.position = (AttackLocation + new Vector3(1f, 0, 0));
        centerRight.SetActive(true);
        StartCoroutine(Hide());
    }

    IEnumerator Hide()
    {
        yield return new WaitForSeconds(1.5f);
        topLeft.SetActive(false);
        topMiddle.SetActive(false);
        topRight.SetActive(false);
        bottomLeft.SetActive(false);
        bottomMiddle.SetActive(false);
        bottomRight.SetActive(false);
        centerLeft.SetActive(false);
        centerRight.SetActive(false);
    }

    public override Vector3 getTargetLocation()
    {
        return TargetLocation;
    }

    public override bool getIsBoss()
    {
        return isBoss;
    }
}
