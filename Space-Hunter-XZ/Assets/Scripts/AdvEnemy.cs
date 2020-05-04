using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvEnemy : MonoBehaviour
{
    public float speed;
    public float currentTime;
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
        currentTime += Time.deltaTime;
        if (currentTime > 1 && currentTime < 1.2)
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
        if (currentTime > 1.2)
        {
            GetComponent<Rigidbody>().velocity = transform.up * -speed * 2;
        }
    }
}
