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
    public Slash slash;
    public FireStorm fireStorm;

    public GameObject upgrade;
    public TMP_Text swordUpgradePrice;

    private BoundsDetector bndDetect;
    private GameObject shop;
    private GameObject mPrompt;
    private GameObject sMenu;
    private GameObject noMoneyButton;
    public GameObject helpText;


    private bool keyBought = false;
    private bool hasUpgraded = false;

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

    public GameObject buy1;
    public GameObject buy2;
    public GameObject buy3;

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
        if(GameLoader.level == 2)
        {
            helpText.gameObject.SetActive(false);
            hasUpgraded = true;
        }
        
        mPrompt.gameObject.SetActive(false);

        if (GameLoader.playerType == 2)
        {
            skillImg2.sprite = ninjaScroll;
            weaponupgradeImg.sprite = ninjaWeaponUpgrade;
        }
        if(GameLoader.playerType == 3)
        {
            skillImg2.sprite = wizardScroll;
            weaponupgradeImg.sprite = wizardWeaponUpgrade;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (bndDetect.isProximityMerchant)
        { 
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
        if (!player.hasDongeonKey && GameLoader.level == 2)
        {
            helpText.gameObject.SetActive(true);
        }
        else
        {
            mPrompt.gameObject.SetActive(true);
        }
    }

    public void OnClickContd()
    {
        mPrompt.gameObject.SetActive(false);
        sMenu.gameObject.SetActive(true);
    }

    public void OnClickExit()
    {
        sMenu.gameObject.SetActive(false);
        helpText.gameObject.SetActive(false);
    }

    public void OnClickNoMoney()
    {
        noMoneyButton.gameObject.SetActive(false);
    }

    public void OnClickSwordUpgrade()
    {
        if(!hasUpgraded && player.coinBalance >= 500)
        {
            player.coinBalance -= 500;
            swordUpgradePrice.text = "Price: 1000 Axils";

            if(GameLoader.playerType == 1)
                upgradeDisplay.sprite = swordUpgrade;
            else if(GameLoader.playerType == 2)
                upgradeDisplay.sprite = ninjaWeaponUpgrade;
            else
                upgradeDisplay.sprite = wizardWeaponUpgrade;

            hasUpgraded = true;
            player.damageMultiplier = 1.5f;
            upgrade.gameObject.SetActive(true);
            Invoke("clearAllUpgrades", 2);
        }
        else if(hasUpgraded && player.coinBalance >= 1000)
        {
            player.coinBalance -= 1000;

            if (GameLoader.playerType == 1)
                upgradeDisplay.sprite = swordUpgrade;
            else if (GameLoader.playerType == 2)
                upgradeDisplay.sprite = ninjaWeaponUpgrade;
            else
                upgradeDisplay.sprite = wizardWeaponUpgrade;

            player.damageMultiplier = 2.0f;
            upgrade.gameObject.SetActive(true);
            Invoke("clearAllUpgrades", 2);
            Destroy(buy2);
        }
        else
        {
            noMoneyButton.gameObject.SetActive(true);
        }
    }

    public void OnClickSlashUpgrade()
    {
        if (player.coinBalance >= 1000)
        {
            player.coinBalance -= 1000;

            if (GameLoader.playerType == 1)
            {
                upgradeDisplay.sprite = swordScroll;
                player.attackList.Add(slash);
            }    
            else if (GameLoader.playerType == 2)
            {
                upgradeDisplay.sprite = ninjaScroll;
                player.attackList.Add(slash);
            }
            else
            {
                upgradeDisplay.sprite = wizardScroll;
                player.attackList.Add(fireStorm);
            }
                

            upgrade.gameObject.SetActive(true);
            Invoke("clearAllUpgrades", 2);
            Destroy(buy1);
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
            Destroy(buy3);
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
