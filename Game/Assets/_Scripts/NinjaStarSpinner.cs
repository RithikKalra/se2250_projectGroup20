using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaStarSpinner : MonoBehaviour
{
    private float rot;
    public float speed;

    void Update()
    {
        rot += Time.deltaTime * speed;

        transform.rotation = Quaternion.Euler(0, 0, rot);
    }
}
