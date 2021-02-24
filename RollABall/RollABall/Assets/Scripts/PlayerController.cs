//Necessary Imports
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using System.Threading.Tasks;

public class PlayerController : MonoBehaviour
{
    //Fields unique to the Player Object
    public float speed = 0;
    //Text display fields
    public TextMeshProUGUI countText; 
    public GameObject winTextObject;

    private GameObject[] pikUps = new GameObject[39];
    private int index = 0;
    private bool delay = false;
    private float timeDelay = 0.0f;
   
    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;

    // Start is called before the first frame update
    void Start()
    {
        //Initializes variables
        rb = GetComponent<Rigidbody>(); //Gets the Rigidbody element for the player object and assigns it to rb
        count = 0;
        SetCountText();
        winTextObject.SetActive(false);
    }
    //Uses InputSystem to determine the direction vectors inputtted by the pressed keys
    void OnMove(InputValue movementValue)
    {
        //Assigns directional vectors to the field variables
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    //Updates the player score and initializes the end game sequence if all the Pickups are collected
    void SetCountText()
    {
        countText.text = "Score: " + count.ToString();
        if(count >= 65)
        {
            winTextObject.SetActive(true);
            delay = true;
        }
    }
    //FixedUpdate runs any number of times a frame
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY); //Creates a 3d vector from the InputSystem direction vectors
        rb.AddForce(movement*speed); //Applies the force to the player object in the direction of the vector and intensity of speed
    }

    //Determines if the player object collides with a Pickup and removes that specific Pickup
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            pikUps[index] = other.gameObject; //Stores the specific Pickup that collided with player object in an array 
            index++; //Increments the array's index

            other.gameObject.SetActive(false); //Removes the pickup from the Scene
            count = count + 2; //Increases Score
            SetCountText();
        }
        if (other.gameObject.CompareTag("PickUp-2")) //Same process for a different type of Pickup score increase differs
        {
            pikUps[index] = other.gameObject;
            index++;

            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
        if (other.gameObject.CompareTag("Object-X")) //Same process for a different type of Pickup score increase differs
        {
            pikUps[index] = other.gameObject;
            index++;

            other.gameObject.SetActive(false);
            count = count + 10;
            SetCountText();
        }
    }

    //Update function runs once per frame
    void Update()
    {
        if(delay == true) //Determines weather EndGame sequence is activated from SetCountText method
        {
            timeDelay += Time.deltaTime; //Delays the Restarting of the game independent of Frame Rate
            if(timeDelay >= 5)
            {
                RestartGame();
            }
        }
    }

    //Resets all PickUp assets and sets the player to the origin point
    private void RestartGame()
    {
        //Resets necessary variables 
        winTextObject.SetActive(false);
        delay = false;
        timeDelay = 0;
        while (index > 0) //Loops through the array that stores all the Pickup objects and displays them back in the Scene
        {
            pikUps[index-1].SetActive(true);
            pikUps[index - 1] = null; //Removes the object from the array
            index--;
        }
        transform.position = new Vector3(0, 1, 0); //Resets player to start
        count = 0;
        SetCountText();

    }
}
