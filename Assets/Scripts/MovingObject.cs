using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    MotionManager motionManag;

    void Start()
    {
        motionManag = FindObjectOfType<MotionManager>();
        motionManag.movingObjects.Add(gameObject.transform);
    }
}
