using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CaveController : MonoBehaviour
{
    private BoundsDetector bndDetect;
    private PlayerController player;


    public GameObject investigateBtn;
    public GameObject nokeyText;
    public GameObject yeskeyText;

    void Awake()
    {
        bndDetect = GameObject.Find("Player").GetComponent<BoundsDetector>();
        player = GameObject.Find("Player").GetComponent<PlayerController>();
    }
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (bndDetect.isProximityCave)
        {
            investigateBtn.gameObject.SetActive(true);
        }
        else
        {
            investigateBtn.gameObject.SetActive(false);
            nokeyText.gameObject.SetActive(false);
            yeskeyText.gameObject.SetActive(false);
        }
    }

    public void OnClickInvestigate()
    {
        if (player.hasKey)
        {
            yeskeyText.gameObject.SetActive(true);
        }
        else
        {
            nokeyText.gameObject.SetActive(true);
        }

    }
    public void OnClickKey()
    {
        SceneManager.LoadScene("Level2_Cave");
    }
    public void OnClickExit()
    {
        yeskeyText.gameObject.SetActive(false);
    }


}
