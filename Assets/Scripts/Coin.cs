using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float spinSpeed;
    [SerializeField] AudioSource myAudio;

    void Update()
    {
        transform.localEulerAngles += Vector3.up * spinSpeed * Time.deltaTime;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<GameManager>().Score();
            myAudio.Play();
            Destroy(gameObject);
        }
        if (other.CompareTag("Destroyer"))
        {
            Destroy(gameObject);
        }

    }
}
