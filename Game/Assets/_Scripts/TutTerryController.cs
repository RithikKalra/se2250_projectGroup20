using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
//update
public class TutTerryController : MonoBehaviour
{
    public TMP_Text challengeText; 

    private BoundsDetector bndDetect;
    private GameObject talk;
    private GameObject ttPrompt;
    private GameObject qMenu;

    public Transform movePoint;
    public Transform HealthBar;
    private HealthSystem healthSystem;
    public Transform Coin;
    public static bool isEnemy = false;

    void Awake()
    {
        bndDetect = GameObject.Find("Player").GetComponent<BoundsDetector>();
        talk = GameObject.FindWithTag("TalkButton");
        ttPrompt = GameObject.FindWithTag("TutTerryPrompt");
        qMenu = GameObject.FindWithTag("QuestMenu");
    }
    // Start is called before the first frame update
    void Start()
    {
        ttPrompt.gameObject.SetActive(false);
        qMenu.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (bndDetect.isProximityTutTerry)
        {
            talk.gameObject.SetActive(true);
        }
        else
        {
            talk.gameObject.SetActive(false);
            ttPrompt.gameObject.SetActive(false);
            qMenu.gameObject.SetActive(false);
        }

        if (isEnemy && healthSystem.GetHealth() <= 0)
        {
            Vector3 pos = gameObject.transform.position;
            Instantiate(Coin, pos, Quaternion.identity);
            Instantiate(Coin, pos, Quaternion.identity);
            gameObject.SetActive(false);
            talk.gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController player = GameObject.Find("Player").GetComponent<PlayerController>();

        if (isEnemy)
        {
            if (other.tag.Equals("Sword"))
            {
                Transform rootT = other.gameObject.transform.root;
                GameObject go = rootT.gameObject;
                healthSystem.Damage((int)player.getDamage());
            }

            if (other.tag.Equals("Arrow"))
            {
                Transform rootT = other.gameObject.transform.root;
                GameObject go = rootT.gameObject;
                healthSystem.Damage((int)player.getDamage());
                go.SetActive(false);
            }
        } 
    }

    public void OnClickTalk()
    {
        ttPrompt.gameObject.SetActive(true);
    }
    public void OnClickNext()
    {
        qMenu.gameObject.SetActive(true);
        ttPrompt.gameObject.SetActive(false);
    }
    public void OnClickExit()
    {
        qMenu.gameObject.SetActive(false);
    }
    public void OnClickChallenge()
    {
        //Turn terry into slime brain
        //The buttons are configured and work there should be a trigger variable or method that begins slime brain code

        isEnemy = true;
        movePoint.parent = null;
        Vector3 pos = gameObject.transform.position + new Vector3(-0.5f, 1f, 0f);
        healthSystem = new HealthSystem(100);

        Transform healthBarTransform = Instantiate(HealthBar, pos, Quaternion.identity);
        HealthBar hb = healthBarTransform.GetComponent<HealthBar>();
        healthBarTransform.transform.parent = gameObject.transform;
        hb.Setup(healthSystem);

        qMenu.gameObject.SetActive(false);

    }
    public void OnClickTutorial()
    {
        //More complicated will figure out after challenge works
        print("This is the tutorial");
    }
}
