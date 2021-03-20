using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//update
//update
public class Interact : MonoBehaviour
{

    public float radius =1f;
    private Transform t;
    private Transform player; 

    // Start is called before the first frame update
    void Start()
    {
        t = this.transform;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(Distance()==radius){
            print("hi im terry"); // to be replaced with a text box in game
        }
    }
    private float Distance()
     {
         return Vector3.Distance(t.position, player.position);
     }
}
