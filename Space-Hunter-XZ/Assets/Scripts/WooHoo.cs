using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WooHoo : MonoBehaviour
{
    public AudioClip woo;
    public float wooTimer;

    private AudioSource audioSource;
    private bool wooPlayed;
    private float time;


    void Start()
    {
        time = Time.time;
        wooPlayed = false;
        audioSource = this.GetComponent<AudioSource>();
    }

    private void Update()
    {
        void Start()
        {
            if (wooPlayed = false && time > wooTimer)
            {
                audioSource.Play();
                wooPlayed = true;
            }
        }
    }
}
