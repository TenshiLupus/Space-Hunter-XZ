using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lifeUp : MonoBehaviour
{
    private GameController gc;
    private AudioSource audioSource;
    void Awake()
    {
        gc = GameObject.FindWithTag("GameController").GetComponent<GameController>();
        audioSource = gc.GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            gc.GiveLife();
            audioSource.PlayOneShot(gc.HPUp);
            Destroy(gameObject);
        }
    }
    
}
