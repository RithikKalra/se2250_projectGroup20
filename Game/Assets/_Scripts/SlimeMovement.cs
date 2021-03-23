using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeMovement : MonoBehaviour
{
    public GameObject Marker;
    public GameObject parent;
    private Vector3 TargetLocation;
    private int horizontal = 0;
    private int vertical = 0;

    public void SelectTarget(){
        if(Marker!=null){
            Destroy(Marker);
        }
    
        System.Random random = new System.Random();
        int randomizer = random.Next(1, 5);
        if (randomizer == 1)
            {
                
                if (horizontal > 2){
                    TargetLocation= new Vector3(-1f, 0f, 0f);
                    horizontal = horizontal -1;
                } else {
                TargetLocation= new Vector3(1f, 0f, 0f);
                horizontal = horizontal +1;
                }
                
            }
        else if (randomizer == 2)
            {
                if (horizontal < -2){
                    TargetLocation= new Vector3(1f, 0f, 0f);
                    horizontal = horizontal +1;
                } else {
                TargetLocation= new Vector3(-1f, 0f, 0f);
                horizontal = horizontal - 1;
            }
            }
        else if (randomizer == 3)
            {
                if (vertical > 2){
                TargetLocation= new Vector3(0f, -1f, 0f);
                vertical = vertical -1;
            } else {
                TargetLocation = new Vector3(0f, 1f, 0f);
                vertical = vertical + 1;
            }
            }
        
        else //heelo
            {
                if (vertical < -2){
                TargetLocation= new Vector3(0f, 1f, 0f);
                vertical = vertical +1;
            } else {
                TargetLocation = new Vector3(0f, -1f, 0f);
                vertical = vertical -1;
            }
            }
        TargetLocation+=parent.transform.position;
        Marker=Instantiate(Marker, TargetLocation, Quaternion.identity);
   }
   public Vector3 getTargetLocation(){
       return TargetLocation;
   }
}
