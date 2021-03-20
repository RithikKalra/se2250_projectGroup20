using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//update
//update
//This class is used to handle all the main players physical interactions with the world
//Aaron use this to set the boundaries of the world and other boundaries
//Should also incorporate all datactions to initiate interactions with enemies and npc's (SuperClass)
public class BoundsDetector : MonoBehaviour
{  
    private GameObject merchant;
    public bool isProximityMerchant = false;

    private GameObject tutTerry;
    public bool isProximityTutTerry = false; //Yo colin wanna use this to detect terry so we just need one script for the main player

    void Awake()
    {
        merchant = GameObject.FindWithTag("ShopKeep");
        tutTerry = GameObject.FindWithTag("TutTerry");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void LateUpdate()
    {

        if (Vector3.Distance(transform.position, merchant.transform.position) < 2)
            isProximityMerchant = true;
        else
            isProximityMerchant = false;

        //Do the same with other NPC's and stuff modify the code if its bad lol
    }
}
