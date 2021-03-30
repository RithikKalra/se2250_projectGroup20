using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeMovement : EnemyMovement
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

    void Start(){

        Marker = Instantiate(Marker, TargetLocation, Quaternion.identity);
        Marker.SetActive(false);

        if (isBoss)
        {
            moveDistance = 2f;
        }
    }

    public override void SelectTarget(){

        if(Marker != null)
        {
            Marker.SetActive(false);
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
                TargetLocation= new Vector3(0f, (moveDistance), 0f);
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
