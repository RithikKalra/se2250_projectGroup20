using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float moveSpeed = 2.0f;
    public Transform movePoint;

    public Transform HealthBar;
    private HealthSystem healthSystem;

    public GameOverScreen GameOverScreen;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        movePoint.parent = null;

        healthSystem = new HealthSystem(100);

        Transform healthBarTransform = Instantiate(HealthBar, new Vector3(0f, 0.5f), Quaternion.identity);
        HealthBar healthBar = healthBarTransform.GetComponent<HealthBar>();
        healthBar.Setup(healthSystem);

        healthBarTransform.transform.parent = GameObject.Find("Player").transform;
    }

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

        if (healthSystem.GetHealth() <= 0)
        {
            GameOver();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Transform rootT = other.gameObject.transform.root;
        GameObject go = rootT.gameObject;

        healthSystem.Damage(10);
    }

    public void GameOver()
    {
        GameOverScreen.Setup();
    }
}
