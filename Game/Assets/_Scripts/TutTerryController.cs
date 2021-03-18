using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//update
public class TutTerryController : MonoBehaviour
{

    private BoundsDetector bndDetect;
    private GameObject talk;
    private GameObject ttPrompt;
    private GameObject qMenu;

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
}
