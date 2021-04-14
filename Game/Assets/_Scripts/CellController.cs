using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellController : MonoBehaviour
{
    private PlayerController player;
    private BoundsDetector bndDetect;

    public GameObject openCell;
    public static bool destroyed = false;
    
    // Start is called before the first frame update
    void Awake()
    {
        bndDetect = GameObject.Find("Player").GetComponent<BoundsDetector>();
        player = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (bndDetect.isProximityJail && player.hasDongeonKey)
        {
            openCell.gameObject.SetActive(true);
        }
        else
        {
            openCell.gameObject.SetActive(false);
        }
    }

    public void OnClickOpenCell()
    {
        player.coinBalance += 1000;
        Destroy(gameObject);
        destroyed = true;
        openCell.gameObject.SetActive(false);
    }
}
