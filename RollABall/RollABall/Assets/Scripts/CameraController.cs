//Necessary Imports
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //Fields for the Camera Object
    public GameObject player;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position; //Calculates the cameras fixed distance from the player object
    }

    // LateUpdate is called once per frame after the Update function
    void LateUpdate()
    {
        transform.position = player.transform.position + offset; //Constantly updates the cameras position to follow the player at the offset's distance
    }
}
