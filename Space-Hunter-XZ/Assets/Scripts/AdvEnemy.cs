using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvEnemy : MonoBehaviour
{
    public float speed;
    void Start()
    {
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
        if (Time.time > 1)
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }
}
