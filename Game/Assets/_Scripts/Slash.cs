using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slash : Attack
{
    public GameObject rSword;
    public GameObject cSword;
    public GameObject lSword;
    private float damage = 15;
    public override float getDamage()
    {
        return damage;
    }
    public override void attack()
    {
        Vector3 AttackLocation= GameObject.Find("Player").transform.position;
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            cSword.transform.position=(AttackLocation+new Vector3(0, 1f, 0));
            cSword.transform.rotation = Quaternion.Euler(new Vector3(0,0,0));
            cSword.SetActive(true);

            lSword.transform.position=(AttackLocation+new Vector3(-1f, 1f, 0));
            lSword.transform.rotation = Quaternion.Euler(new Vector3(0,0,0));
            lSword.SetActive(true);

            rSword.transform.position=(AttackLocation+new Vector3(1f, 1f, 0));
            rSword.transform.rotation = Quaternion.Euler(new Vector3(0,0,0));
            rSword.SetActive(true);

            StartCoroutine(Hide());
        }
        else if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            cSword.transform.position=(AttackLocation+new Vector3(-1, 0, 0));
            cSword.transform.rotation = Quaternion.Euler(new Vector3(0,0,90));
            cSword.SetActive(true);

            lSword.transform.position=(AttackLocation+new Vector3(-1, -1, 0));
            lSword.transform.rotation = Quaternion.Euler(new Vector3(0,0,90));
            lSword.SetActive(true);

            rSword.transform.position=(AttackLocation+new Vector3(-1, 1, 0));
            rSword.transform.rotation = Quaternion.Euler(new Vector3(0,0,90));
            rSword.SetActive(true);
            StartCoroutine(Hide());
        }
        else if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            cSword.transform.position=(AttackLocation+new Vector3(0, -1f, 0));
            cSword.transform.rotation = Quaternion.Euler(new Vector3(0,0,180));
            cSword.SetActive(true);

            lSword.transform.position=(AttackLocation+new Vector3(1, -1f, 0));
            lSword.transform.rotation = Quaternion.Euler(new Vector3(0,0,180));
            lSword.SetActive(true);

            rSword.transform.position=(AttackLocation+new Vector3(-1, -1f, 0));
            rSword.transform.rotation = Quaternion.Euler(new Vector3(0,0,180));
            rSword.SetActive(true);
            StartCoroutine(Hide());
        }
        else if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            cSword.transform.position=(AttackLocation+new Vector3(1, 0, 0));
            cSword.transform.rotation = Quaternion.Euler(new Vector3(0,0,270));
            cSword.SetActive(true);

            lSword.transform.position=(AttackLocation+new Vector3(1, 1, 0));
            lSword.transform.rotation = Quaternion.Euler(new Vector3(0,0,270));
            lSword.SetActive(true);

            rSword.transform.position=(AttackLocation+new Vector3(1, -1, 0));
            rSword.transform.rotation = Quaternion.Euler(new Vector3(0,0,270));
            rSword.SetActive(true);
            StartCoroutine(Hide());
        }
    }
    IEnumerator Hide()
    {
        yield return new WaitForSeconds(1.5f);
        cSword.SetActive(false);
        lSword.SetActive(false);
        rSword.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        cSword = Instantiate(cSword, new Vector3(0, 0, 0), Quaternion.identity);
        cSword.SetActive(false);
        lSword = Instantiate(cSword, new Vector3(0, 0, 0), Quaternion.identity);
        lSword.SetActive(false);
        rSword = Instantiate(cSword, new Vector3(0, 0, 0), Quaternion.identity);
        rSword.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
