using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeMovement : MonoBehaviour
{
    public GameObject Marker;
    public GameObject parent;
    private Vector3 TargetLocation;

    public void SelectTarget(){
        if(Marker!=null){
            Destroy(Marker);
        }
        System.Random random = new System.Random();
        int randomizer = random.Next(1, 5);
        if (randomizer == 1)
            {
                TargetLocation= new Vector3(1f, 0f, 0f);
                
            }
        else if (randomizer == 2)
            {
                TargetLocation= new Vector3(-1f, 0f, 0f);
            }
        else if (randomizer == 3)
            {
                TargetLocation= new Vector3(0f, 1f, 0f);
            }
        
        else //heelo
            {
                TargetLocation= new Vector3(0f, -1f, 0f);
            }
        TargetLocation+=parent.transform.position;
        Marker=Instantiate(Marker, TargetLocation, Quaternion.identity);
   }
   public Vector3 getTargetLocation(){
       return TargetLocation;
   }
}
