using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;

    private AudioSource audioSource;
    private float nextFire;
    private bool isReady;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Invoke("SetReady", 2f);
    }

    private void SetReady()
    {
        audioSource.volume = 0.2f;
        isReady = true;
    }

    void Update()
    {
        if(Time.time>nextFire && isReady){
            nextFire = Time.time + fireRate;
            Instantiate (shot, shotSpawn.position, shotSpawn.rotation );
            audioSource.Play();
        }

    }
}
