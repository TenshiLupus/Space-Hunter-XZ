using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public float speed;
    void Start(){
        GetComponent<Rigidbody>().velocity = transform.up * speed; 
       // DestroyObjectDelayed();
    }

        void DestroyObjectDelayed()
    {
        // Kills the game object in X seconds after loading the object
        Destroy(gameObject, 1);
    }
}
