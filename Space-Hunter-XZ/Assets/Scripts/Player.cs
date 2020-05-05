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
             void OnTriggerEnter(Collider other)
         {
            if (other.tag == "Hazard")
            {
              StartCoroutine(Flasher()); //VERY IMPORTANT!  You 'must' start coroutines with this code.
            }
         }

    IEnumerator Flasher() 
{
    for (int i = 0; i < 5; i++)
    {
    Color tempColor = GetComponent<Renderer>().material.color;
    GetComponent<Renderer>().material.color = Color.white;
    yield return new WaitForSeconds(.1f);
    GetComponent<Renderer>().material.color = tempColor; 
    yield return new WaitForSeconds(.1f);
    }
}
}

