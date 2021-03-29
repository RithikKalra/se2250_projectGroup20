using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyMovement : MonoBehaviour
{
    public GameObject Marker;
    public abstract void SelectTarget();
   public abstract Vector3 getTargetLocation();
}
