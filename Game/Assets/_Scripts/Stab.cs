using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stab : Attack
{
    public GameObject Sword;
    private float damage = 10;
    public override float getDamage()
    {
        return damage;
    }
    public override void attack()
    {
        Vector3 AttackLocation= GameObject.Find("Player").transform.position;
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            Sword.transform.position=(AttackLocation+new Vector3(0, 1f, 0));
            Sword.transform.rotation = Quaternion.Euler(new Vector3(0,0,0));
            Sword.SetActive(true);
            StartCoroutine(Hide());
        }
        else if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Sword.transform.position=(AttackLocation+new Vector3(-1, 0, 0));
            Sword.transform.rotation = Quaternion.Euler(new Vector3(0,0,90));
            Sword.SetActive(true);
            StartCoroutine(Hide());
        }
        else if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            Sword.transform.position=(AttackLocation+new Vector3(0, -1f, 0));
            Sword.transform.rotation = Quaternion.Euler(new Vector3(0,0,180));
            Sword.SetActive(true);
            StartCoroutine(Hide());
        }
        else if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            Sword.transform.position=(AttackLocation+new Vector3(1, 0, 0));
            Sword.transform.rotation = Quaternion.Euler(new Vector3(0,0,270));
            Sword.SetActive(true);
            StartCoroutine(Hide());
        }
    }
    IEnumerator Hide()
  {
    yield return new WaitForSeconds(1.5f);
    Sword.SetActive(false);
  }

    // Start is called before the first frame update
    void Start()
    {
        Sword=Instantiate(Sword, new Vector3(0, 0, 0), Quaternion.identity);
        Sword.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
