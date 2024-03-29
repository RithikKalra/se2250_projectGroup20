﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//update
//This class is used to handle all the main players physical interactions with the world
//Aaron use this to set the boundaries of the world and other boundaries
//Should also incorporate all datactions to initiate interactions with enemies and npc's (SuperClass)
public class BoundsDetector : MonoBehaviour
{  
    private GameObject merchant;
    public bool isProximityMerchant = false;

    private GameObject tutTerry;
    public bool isProximityTutTerry = false;

    private GameObject caveEntrance;
    public bool isProximityCave = false;

    private GameObject jailCell;
    public bool isProximityJail = false;

    

    void Awake()
    {
        merchant = GameObject.FindWithTag("ShopKeep");
        tutTerry = GameObject.FindWithTag("TutTerry");
        caveEntrance = GameObject.FindWithTag("CaveEntrance");
        jailCell = GameObject.FindWithTag("JailCell");
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
        if(GameLoader.level == 1)
        {
            if (Vector3.Distance(transform.position, tutTerry.transform.position) < 2)
                isProximityTutTerry = true;
            else
                isProximityTutTerry = false;

            if (Vector3.Distance(transform.position, caveEntrance.transform.position) < 2)
                isProximityCave = true;
            else
                isProximityCave = false;
        }
        if(GameLoader.level == 2 && !CellController.destroyed)
        {
            if (Vector3.Distance(transform.position, jailCell.transform.position) < 2)
                isProximityJail = true;
            else
                isProximityJail = false;
        }

        if (Vector3.Distance(transform.position, merchant.transform.position) < 2)
            isProximityMerchant = true;
        else
            isProximityMerchant = false;
    }
}
