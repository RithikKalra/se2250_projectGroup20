using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//update
//update
public class CameraController : MonoBehaviour
{
    public GameObject player;
    private float offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position.y - player.transform.position.y;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //transform.position.y = player.transform.position.y + offset;
    }
}
