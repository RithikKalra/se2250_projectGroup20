using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMovement : MonoBehaviour
{
    public float amplitude = 0.5f;
    public float frequency = 1f;
    public bool isCrystal;

    Vector3 posOffset = new Vector3();
    Vector3 tempPos = new Vector3();

    void Start()
    {
        posOffset = transform.position;
    }

    void Update()
    {
        if (isCrystal)
        {
            transform.Rotate(0, 1, 0, Space.World);
        }

        tempPos = posOffset;
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;

        transform.position = tempPos;
    }
}
