using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireStorm : Attack
{
    public GameObject fireStorm1;
    public GameObject fireStorm2;
    public bool active1=false;
    public bool active2=false;
    private float damage = 10;
    public override float getDamage()
    {
        return damage;
    }
    void Start()
    {
        fireStorm1= Instantiate(fireStorm1, new Vector3(0, 0, 0), Quaternion.identity);
        fireStorm1.SetActive(false);
        fireStorm2= Instantiate(fireStorm2, new Vector3(0,0,0), Quaternion.identity);
        fireStorm2.SetActive(false);
    }

    public override void attack()
    {
        Vector3 AttackLocation= GameObject.Find("Player").transform.position;
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            if(!active1){
                up(fireStorm1, AttackLocation);
                active1=true;
                StartCoroutine(Hide(fireStorm1, 1));
            }
            else if(!active2){
                up(fireStorm2, AttackLocation);
                active2=true;
                StartCoroutine(Hide(fireStorm2, 2));
            }
            
        }
        else if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if(!active1){
                left(fireStorm1, AttackLocation);
                active1=true;
                StartCoroutine(Hide(fireStorm1, 1));
            }
            else if(!active2){
                left(fireStorm2, AttackLocation);
                active2=true;
                StartCoroutine(Hide(fireStorm2, 2));
            }

        }
        else if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            if(!active1){
                down(fireStorm1, AttackLocation);
                active1=true;
                StartCoroutine(Hide(fireStorm1, 1));
            }
            else if(!active2){
                down(fireStorm2, AttackLocation);
                active2=true;
                StartCoroutine(Hide(fireStorm2, 2));
            }
            
        }
        else if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            if(!active1){
                right(fireStorm1, AttackLocation);
                active1=true;
                StartCoroutine(Hide(fireStorm1, 1));
            }
            else if(!active2){
                right(fireStorm2, AttackLocation);
                active2=true;
                StartCoroutine(Hide(fireStorm2, 2));
            }
            
        }
    }

    public void up(GameObject fStorm, Vector3 AttackLocation){
            fStorm.transform.position=(AttackLocation+new Vector3(0, 2f, 0));
            fStorm.transform.rotation = Quaternion.Euler(new Vector3(0,0,0));
            fStorm.SetActive(true);
    }
    public void left(GameObject fStorm, Vector3 AttackLocation){
            fStorm.transform.position=(AttackLocation+new Vector3(-2f, 0, 0));
            fStorm.transform.rotation = Quaternion.Euler(new Vector3(0,0,0));
            fStorm.SetActive(true);
    }
    public void down(GameObject fStorm, Vector3 AttackLocation){
            fStorm.transform.position=(AttackLocation+new Vector3(0, -2f, 0));
            fStorm.transform.rotation = Quaternion.Euler(new Vector3(0,0,0));
            fStorm.SetActive(true);
    }
    public void right(GameObject fStorm, Vector3 AttackLocation){
            fStorm.transform.position=(AttackLocation+new Vector3(2f, 0, 0));
            fStorm.transform.rotation = Quaternion.Euler(new Vector3(0,0,0));
            fStorm.SetActive(true);
    }
    IEnumerator Hide(GameObject fStorm, int active)
    {
        yield return new WaitForSeconds(1.5f);
        fStorm.SetActive(false);
        if(active==1){
            active1=false;
        }
        else{
            active2=false;
        }
        
    }
}
