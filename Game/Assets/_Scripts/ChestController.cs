using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour
{
    public Sprite openChest;
    public Sprite closedChest;
    public Sprite skull;
    public string chestType;

    public GameObject openChestBtn;
    public GameObject nothingMessage;
    private GameObject player;

    private BoundsDetector bndDetect;

    void Awake()
    {
        bndDetect = GameObject.Find("Player").GetComponent<BoundsDetector>();
        player = GameObject.Find("Player");
    }
    // Start is called before the first frame update
    void Start()
    {
        openChestBtn.gameObject.SetActive(false);
        nothingMessage.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < 1.5f)
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
        }
        else if (chestType.Equals("heart"))
        {
        }
        else
        {
            //Add mimic code here
        }
    }
}
