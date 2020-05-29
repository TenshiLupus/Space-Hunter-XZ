using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvEnemy : MonoBehaviour
{
    public float speed;
    public float tilt;
    public float waitTime;

    private float currentTime;
    private float timer;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        timer = Random.Range(0.75f, 1.05f);
        if (GetComponent<Transform>().position.x < 0)
        {
            GetComponent<Rigidbody>().velocity = transform.right * speed;
        }
        else if (GetComponent<Transform>().position.x > 0)
        {
            GetComponent<Rigidbody>().velocity = transform.right * -speed;
        }
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime > timer && currentTime < timer + 1)
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
        if (currentTime > waitTime)
        {
            GetComponent<Rigidbody>().velocity = transform.up * -speed * 1.5f;
        }
    }

    private void FixedUpdate()
    {
        rb.rotation = Quaternion.Euler(0.0f, Mathf.Clamp(rb.velocity.x * -tilt, -45f, 45f), 0.0f);
    }
}
