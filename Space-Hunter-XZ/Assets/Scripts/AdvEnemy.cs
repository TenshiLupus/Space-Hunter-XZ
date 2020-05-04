using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvEnemy : MonoBehaviour
{
    public float speed;
    
    private float currentTime;
    private float timerStrafe;
    void Start()
    {
        timerStrafe = Random.Range(0.9f, 1.0f);
        if (GetComponent<Transform>().position.x < 0)
        {
            GetComponent<Rigidbody>().velocity = transform.right * speed;
        } else if (GetComponent<Transform>().position.x > 0)
        {
            GetComponent<Rigidbody>().velocity = transform.right * -speed;
        }
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime > timerStrafe && currentTime < timerStrafe + 1)
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
        if (currentTime > 2)
        {
            GetComponent<Rigidbody>().velocity = transform.up * -speed;
        }
    }
}
