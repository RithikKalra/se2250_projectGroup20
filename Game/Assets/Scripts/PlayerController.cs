using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float moveSpeed = 2.0f;
    public Transform movePoint;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        movePoint.parent = null;
    }
// epic test 69


    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, movePoint.position) == 0f)
        {
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
                movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
            else if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
                movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
        }
    }
}
