using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : Attack
{
    public Transform arrow;
    private float damage = 50;
    public GameObject arrowParent;

    public override float getDamage()
    {
        return damage;
    }

    // Start is called before the first frame update
    void Start()
    {
        Vector3 pos = gameObject.transform.position;
        arrow = Instantiate(arrow, pos, Quaternion.Euler(new Vector3(0, 0, 90)));
        arrow.transform.parent = GameObject.Find("ArrowParent").transform;
        arrowParent.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void attack()
    {
        Vector3 pos = gameObject.transform.position;
        Vector3 AttackLocation = GameObject.Find("Player").transform.position;

        arrow.transform.position = pos;

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            arrow.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
            arrowParent.SetActive(true);

            arrowParent.GetComponent<Rigidbody2D>().AddForce(arrowParent.transform.up * 200);
            StartCoroutine(Hide());
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            arrowParent.SetActive(true);
            arrowParent.GetComponent<Rigidbody2D>().AddForce(-arrowParent.transform.right * 200);
            StartCoroutine(Hide());
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            arrow.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
            arrowParent.SetActive(true);

            arrowParent.GetComponent<Rigidbody2D>().AddForce(-arrowParent.transform.up * 200);
            StartCoroutine(Hide());
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            arrowParent.SetActive(true);
            arrowParent.GetComponent<Rigidbody2D>().AddForce(arrowParent.transform.right * 200);
            StartCoroutine(Hide());
        }
    }

    IEnumerator Hide()
    {
        yield return new WaitForSeconds(1f);
        arrowParent.SetActive(false);
    }
}
