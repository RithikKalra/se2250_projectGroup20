using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//This class is used to handle player interactions with the merchant
public class MerchantController : MonoBehaviour
{
    private BoundsDetector bndDetect;
    private GameObject shop;
    private GameObject sMenu;
  
    void Awake()
    {
        bndDetect = GameObject.Find("Player").GetComponent<BoundsDetector>();
        shop = GameObject.FindWithTag("ShopButton");
        sMenu = GameObject.FindWithTag("ShopMenu");
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
            shop.gameObject.SetActive(true);
        }
        else
        {
            shop.gameObject.SetActive(false);
            sMenu.gameObject.SetActive(false);
        }
    }

    public void onClickShop()
    {
        sMenu.gameObject.SetActive(true);
    }


}
