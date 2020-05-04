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

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(Time.time>nextFire){
            nextFire = Time.time + fireRate;
            Instantiate (shot, shotSpawn.position, shotSpawn.rotation );
            audioSource.Play();
        }

    }
}
