using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float moveSpeed = 2.0f;
    public Transform movePoint;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        movePoint.parent = null;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, movePoint.position) == 0f)
        {
            Move();
        }
    }

    void Move()
    {
        System.Random random = new System.Random();
        int randomizer = random.Next(1, 5);

        if (randomizer == 1)
        {
            movePoint.position += new Vector3(1f, 0f, 0f);
        }
        else if (randomizer == 2)
        {
            movePoint.position += new Vector3(-1f, 0f, 0f);
        }
        else if (randomizer == 3)
        {
            movePoint.position += new Vector3(0f, 1f, 0f);
        }
        else if (randomizer == 4)
        {
            movePoint.position += new Vector3(0f, -1f, 0f);
        }
    }
}
