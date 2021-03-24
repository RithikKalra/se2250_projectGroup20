using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//This class is used to handle player interactions with the merchant
//update
public class MerchantController : MonoBehaviour
{

    public PlayerController player;

    public GameObject swordUpgrade;
    public TMP_Text swordUpgradePrice;

    private BoundsDetector bndDetect;
    private GameObject shop;
    private GameObject mPrompt;
    private GameObject sMenu;
    private GameObject noMoneyButton;

  
    void Awake()
    {
        bndDetect = GameObject.Find("Player").GetComponent<BoundsDetector>();
        shop = GameObject.FindWithTag("ShopButton");
        mPrompt = GameObject.FindWithTag("MerchantPrompt");
        sMenu = GameObject.FindWithTag("ShopMenu");
        noMoneyButton = GameObject.FindWithTag("NoMoney");
    }
    // Start is called before the first frame update
    void Start()
    {
        mPrompt.gameObject.SetActive(false);
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
            mPrompt.gameObject.SetActive(false);
            sMenu.gameObject.SetActive(false);
            noMoneyButton.gameObject.SetActive(false);
            swordUpgrade.gameObject.SetActive(false);
        }
    }

    //Button methods
    public void OnClickShop()
    {
        mPrompt.gameObject.SetActive(true);
    }

    public void OnClickContd()
    {
        mPrompt.gameObject.SetActive(false);
        sMenu.gameObject.SetActive(true);
    }

    public void OnClickExit()
    {
        sMenu.SetActive(false);
    }

    public void OnClickNoMoney()
    {
        noMoneyButton.gameObject.SetActive(false);
    }

    public void OnClickSwordUpgrade()
    {
        if(player.coinBalance >= 200)
        {
            player.coinBalance -= 200;
            swordUpgradePrice.text = "Price: 300 Axils";
            swordUpgrade.gameObject.SetActive(true);
            Invoke("clearAllUpgrades", 2);
        }
        else
        {
            noMoneyButton.gameObject.SetActive(true);
        }
    }

    public void OnClickThrustUpgrade()
    {
        if (player.coinBalance >= 500)
        {
            player.coinBalance -= 500;
        }
        else
        {
            noMoneyButton.gameObject.SetActive(true);
        }
    }

    public void OnClickSlashUpgrade()
    {
        if (player.coinBalance >= 1500)
        {
            player.coinBalance -= 1500;
        }
        else
        {
            noMoneyButton.gameObject.SetActive(true);
        }
    }

    public void clearAllUpgrades()
    {
        swordUpgrade.gameObject.SetActive(false);
    }


}
