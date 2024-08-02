using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionManager : MonoBehaviour
{
    public bool isSimulated = false;
    [SerializeField] float baseMoveSpeed;
    public List<Transform> movingObjects = new List<Transform>();

    GameManager gameManag;
    float realMoveSpeed;

    private void Start()
    {
        if(!isSimulated)
        {
            gameManag = FindObjectOfType<GameManager>();
        }

        UpdateTimers();
    }

    private void Update()
    {
        foreach(var obj in movingObjects)
        {
            obj.transform.position += Vector3.back * realMoveSpeed * Time.deltaTime;
        }
    }

    public void UpdateTimers()
    {
        if(!isSimulated)
        {
            realMoveSpeed = baseMoveSpeed * gameManag.gameSpeedMultioplier;
        }
        else
        {
            realMoveSpeed = baseMoveSpeed;
        }
    }
}
