using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour
{
    public PlayerController rPlayer;

    public Sprite openChest;
    public Sprite closedChest;
    public Sprite skull;
    public string chestType;
    public Animator anim;
    public GameObject jailkey;

    public bool isOpen = false;

    public GameObject openChestBtn;
    private GameObject nothingMessage;
    private GameObject player;

    private BoundsDetector bndDetect;

    void Awake()
    {
        bndDetect = GameObject.Find("Player").GetComponent<BoundsDetector>();
        nothingMessage = GameObject.FindWithTag("ChestOpen");
        player = GameObject.Find("Player");
    }
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        openChestBtn.gameObject.SetActive(false);
        nothingMessage.gameObject.SetActive(false);
        jailkey.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < 1.5f && !isOpen)
        {
            openChestBtn.gameObject.SetActive(true);
        }
        if(Vector3.Distance(transform.position, player.transform.position) < 3 && Vector3.Distance(transform.position, player.transform.position) > 1.5f)
        {
            openChestBtn.gameObject.SetActive(false);
            nothingMessage.gameObject.SetActive(false);
        }     
    }

    public void OnClickOpen()
    {
        if (chestType.Equals("nothing"))
        {
            nothingMessage.gameObject.SetActive(true);
        }
        else if (chestType.Equals("key"))
        {
            isOpen = true;
            rPlayer.hasDongeonKey = true;
            anim.SetTrigger("Active");
            Invoke("obtainKey", 1);
            Invoke("clearScreen", 4);
        }
        else if (chestType.Equals("heart"))
        {
        }
        else
        {
            //Add mimic code here
        }
    }
    public void obtainKey()
    {
        jailkey.gameObject.SetActive(true);
    }
    public void clearScreen()
    {
        jailkey.gameObject.SetActive(false);
    }
}
