using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfMovement : MonoBehaviour
{
    public GameObject Marker;
    public GameObject parent;
    private Vector3 TargetLocation;
    private int horizontal = 0;
    private int vertical = 0;
    public int pHorizontal;
    public int nHorizontal;
    public int pVertical;
    public int nVertical;

    public void SelectTarget()
    {
        if (Marker != null)
        {
            Destroy(Marker);
        }

        System.Random random = new System.Random();
        int randomizer = random.Next(1, 5);
        if (randomizer == 1)
        {

            if (horizontal > pHorizontal)
            {
                TargetLocation = new Vector3(-2f, 0f, 0f);
                horizontal = horizontal - 2;
            }
            else
            {
                TargetLocation = new Vector3(2f, 0f, 0f);
                horizontal = horizontal + 2;
            }

        }
        else if (randomizer == 2)
        {
            if (horizontal < nHorizontal)
            {
                TargetLocation = new Vector3(2f, 0f, 0f);
                horizontal = horizontal + 2;
            }
            else
            {
                TargetLocation = new Vector3(-2f, 0f, 0f);
                horizontal = horizontal - 2;
            }
        }
        else if (randomizer == 3)
        {
            if (vertical > pVertical)
            {
                TargetLocation = new Vector3(0f, -2f, 0f);
                vertical = vertical - 2;
            }
            else
            {
                TargetLocation = new Vector3(0f, 2f, 0f);
                vertical = vertical + 2;
            }
        }

        else //heelo
        {
            if (vertical < nVertical)
            {
                TargetLocation = new Vector3(0f, 2f, 0f);
                vertical = vertical + 2;
            }
            else
            {
                TargetLocation = new Vector3(0f, -2f, 0f);
                vertical = vertical - 2;
            }
        }
        TargetLocation += parent.transform.position;
        Marker = Instantiate(Marker, TargetLocation, Quaternion.identity);
    }
    public Vector3 getTargetLocation()
    {
        return TargetLocation;
    }
}
