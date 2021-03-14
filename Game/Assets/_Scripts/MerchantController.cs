using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class is used to handle player interactions with the merchant
public class MerchantController : MonoBehaviour
{
    private BoundsDetector bndDetect;

    void Awake()
    {
        bndDetect = GameObject.Find("Player").GetComponent<BoundsDetector>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (bndDetect.isProximityMerchant)
        {
            //Run methods that involve merchant interactions here!
            print("Hi Son");
        }
    }
}
