using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float LerpSpeed;
    [SerializeField] LayerMask groundMask;
    [SerializeField] Transform leftAnchor;
    [SerializeField] Transform middleAnchor;
    [SerializeField] Transform rightAnchor;
    [SerializeField] GroundCheck myCube;
    [SerializeField] AudioSource SlideSound;
    [SerializeField] AudioSource JumpSound;
    [SerializeField] AudioSource CrouchSound;

    Animator myAnim;

    // -1   - Left
    //  0   - Middle
    //  1   - Right
    int currentPosition = 0;

    bool isSliding = false;

    private void Start()
    {
        transform.position = middleAnchor.transform.position;
        myAnim = GetComponent<Animator>();
    }

    void Update()
    {
        // current anchor manipulation
        if(Input.GetKeyDown(KeyCode.A) && !isSliding)
        {
            currentPosition--;
            SlideSound.Play();
        }
        else if(Input.GetKeyDown(KeyCode.D) && !isSliding)
        {
            currentPosition++;
            SlideSound.Play();
        }
        currentPosition = (currentPosition == -2) ? -1 : currentPosition;
        currentPosition = (currentPosition == 2) ? 1 : currentPosition;

        // jump and slide
        if(Input.GetKeyDown(KeyCode.S))
        {
            myAnim.SetTrigger("Slide");
            CrouchSound.Play();
        }
        if(Input.GetKeyDown(KeyCode.W) && myCube.isGrounded())
        {
            myAnim.SetTrigger("Jump");
            JumpSound.Play();
        }


        // lerping into anchor position
        switch (currentPosition)
        {
            case -1:
                transform.position = Vector3.Lerp(transform.position, new Vector3(leftAnchor.position.x, transform.position.y, transform.position.z) , LerpSpeed);
                break;
            case 0:
                transform.position = Vector3.Lerp(transform.position, new Vector3(middleAnchor.position.x, transform.position.y, transform.position.z), LerpSpeed);
                break;
            case 1:
                transform.position = Vector3.Lerp(transform.position, new Vector3(rightAnchor .position.x, transform.position.y, transform.position.z), LerpSpeed);
                break;
        }

    }
}
