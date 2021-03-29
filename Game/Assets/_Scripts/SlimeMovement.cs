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

    void Start(){
        Marker=Instantiate(Marker, TargetLocation, Quaternion.identity);
        Marker.SetActive(false);
    }

    public override void SelectTarget(){
        if(Marker!=null){
            Marker.SetActive(false);
            //Destroy(Marker);
        }
    
        System.Random random = new System.Random();
        int randomizer = random.Next(1, 5);
        if (randomizer == 1)
            {
                
                if (horizontal > pHorizontal){
                    TargetLocation= new Vector3(-1f, 0f, 0f);
                    horizontal = horizontal -1;
                } else {
                TargetLocation= new Vector3(1f, 0f, 0f);
                horizontal = horizontal +1;
                }
                
            }
        else if (randomizer == 2)
            {
                if (horizontal < nHorizontal){
                    TargetLocation= new Vector3(1f, 0f, 0f);
                    horizontal = horizontal +1;
                } else {
                TargetLocation= new Vector3(-1f, 0f, 0f);
                horizontal = horizontal - 1;
            }
            }
        else if (randomizer == 3)
            {
                if (vertical > pVertical){
                TargetLocation= new Vector3(0f, -1f, 0f);
                vertical = vertical -1;
            } else {
                TargetLocation = new Vector3(0f, 1f, 0f);
                vertical = vertical + 1;
            }
            }
        
        else //heelo
            {
                if (vertical < nVertical){
                TargetLocation= new Vector3(0f, 1f, 0f);
                vertical = vertical +1;
            } else {
                TargetLocation = new Vector3(0f, -1f, 0f);
                vertical = vertical -1;
            }
            }
        TargetLocation+=parent.transform.position;
        Marker.transform.position=TargetLocation;
        Marker.SetActive(true);
        //Marker=Instantiate(Marker, TargetLocation, Quaternion.identity);
   }
   public override Vector3 getTargetLocation(){
       return TargetLocation;
   }
}
