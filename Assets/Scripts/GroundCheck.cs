using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] float extraRayHeight = 1f;

    public bool isGrounded()
    {
        return Physics.Raycast(GetComponent<BoxCollider>().bounds.center, Vector3.down, GetComponent<BoxCollider>().bounds.extents.y + extraRayHeight);
    }
}
