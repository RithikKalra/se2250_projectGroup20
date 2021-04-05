using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombAction : MonoBehaviour
{
    public int direction;
    public Transform source;
    // Update is called once per frame
    void Update()
    {
        switch (direction)
                {
                    case 1:
                        gameObject.GetComponent<Rigidbody2D>().AddForce(source.right * 25);
                        break;
                    case 2:
                        gameObject.GetComponent<Rigidbody2D>().AddForce(source.up * 25);
                        break;
                    case 3:
                        gameObject.GetComponent<Rigidbody2D>().AddForce(-source.right * 25);
                        break;
                    case 4:
                        gameObject.GetComponent<Rigidbody2D>().AddForce(-source.up * 25);
                        break;
                    default:
                        break;
                }
        
    }
    public void setUp(int dir, Vector3 spawnPoint, Transform start){
        direction=dir;
        gameObject.transform.position=spawnPoint;
        source=start;
        switch (dir)
                {
                    case 1:
                        gameObject.transform.rotation=Quaternion.Euler(new Vector3(0,0,0));
                        break;
                    case 2:
                        gameObject.transform.rotation=Quaternion.Euler(new Vector3(0,0,90));
                        break;
                    case 3:
                        gameObject.transform.rotation=Quaternion.Euler(new Vector3(0,0,180));
                        break;
                    case 4:
                        gameObject.transform.rotation=Quaternion.Euler(new Vector3(0,0,270));
                        break;
                    default:
                        gameObject.transform.rotation=Quaternion.Euler(new Vector3(0,0,0));
                        break;
                }
    }
}
