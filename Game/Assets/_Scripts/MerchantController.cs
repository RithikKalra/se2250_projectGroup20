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

    public GameObject upgrade;
    public TMP_Text swordUpgradePrice;

    private BoundsDetector bndDetect;
    private GameObject shop;
    private GameObject mPrompt;
    private GameObject sMenu;
    private GameObject noMoneyButton;

    private bool keyBought = false;

    public Image skillImg1;
    public Image skillImg2;
    public Image weaponupgradeImg;
    public Image upgradeDisplay;

    public Sprite swordScroll;
    public Sprite swordUpgrade;
    public Sprite dimentionalKey;
    public Sprite ninjaScroll;
    public Sprite ninjaWeaponUpgrade;
    public Sprite wizardScroll;
    public Sprite wizardWeaponUpgrade;
    public Sprite drinkPotion;

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

        if(GameLoader.playerType == 2)
        {
            skillImg1.sprite = ninjaScroll;
            skillImg2.sprite = ninjaScroll;
            weaponupgradeImg.sprite = ninjaWeaponUpgrade;
        }
        if(GameLoader.playerType == 3)
        {
            skillImg1.sprite = wizardScroll;
            skillImg2.sprite = wizardScroll;
            weaponupgradeImg.sprite = wizardWeaponUpgrade;
        }
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
            upgrade.gameObject.SetActive(false);
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

            if(GameLoader.playerType == 1)
                upgradeDisplay.sprite = swordUpgrade;
            else if(GameLoader.playerType == 2)
                upgradeDisplay.sprite = ninjaWeaponUpgrade;
            else
                upgradeDisplay.sprite = wizardWeaponUpgrade;

            upgrade.gameObject.SetActive(true);
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

            if (GameLoader.playerType == 1)
                upgradeDisplay.sprite = swordScroll;
            else if (GameLoader.playerType == 2)
                upgradeDisplay.sprite = ninjaScroll;
            else
                upgradeDisplay.sprite = wizardScroll;

            upgrade.gameObject.SetActive(true);
            Invoke("clearAllUpgrades", 2);
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

            if (GameLoader.playerType == 1)
                upgradeDisplay.sprite = swordScroll;
            else if (GameLoader.playerType == 2)
                upgradeDisplay.sprite = ninjaScroll;
            else
                upgradeDisplay.sprite = wizardScroll;

            upgrade.gameObject.SetActive(true);
            Invoke("clearAllUpgrades", 2);
        }
        else
        {
            noMoneyButton.gameObject.SetActive(true);
        }
    }
    public void OnClickDimentionalKey()
    {
        if(player.coinBalance >= 800 && !keyBought && player.hasCrystal)
        {
            player.coinBalance -= 800;
            player.hasCrystal = false;
            player.hasKey = true;
            player.itemHolder.sprite = player.key;

            upgradeDisplay.sprite = dimentionalKey;
            upgrade.gameObject.SetActive(true);
            Invoke("clearAllUpgrades", 2);
        }
        else if(keyBought){
            print("You cannot but a second key!");
        }
        else if (!player.hasCrystal)
        {
            print("You do not posses the materials required!");
        }
        else
        {
            noMoneyButton.gameObject.SetActive(true);
        }
    }
    public void OnClickHealth()
    {
        if (player.coinBalance >= 100)
        {
            player.coinBalance -= 100;

            player.HealPlayer();
            upgradeDisplay.sprite = drinkPotion;
            upgrade.gameObject.SetActive(true);
            Invoke("clearAllUpgrades", 2);

        }
        else
        {
            noMoneyButton.gameObject.SetActive(true);
        }      
    }
    public void clearAllUpgrades()
    {
        upgrade.gameObject.SetActive(false);
    }


}
