using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvEnemy : MonoBehaviour
{
    public Transform scaleReference;
    public float speedSide;
    public float speedDown;
    public float tilt;
    public float waitTime;
    public GameObject left;
    public GameObject right;

    private Rigidbody rb;

    private float currentTime;
    private float timer;
    void Start()
    {
        scaleReference = GameObject.Find("ScaleReference").transform;
        rb = GetComponent<Rigidbody>();
        timer = Random.Range(0.75f, 1.05f);
        speedSide = speedSide * (scaleReference.position.x / 5.625f);
        left = GameObject.Find("BoundaryLeft");
        right = GameObject.Find("BoundaryRight");
        if (speedSide < 6)
        {
            speedSide = 6;
        }
        if (rb.position.x < 0)
        {
            rb.velocity = transform.right * speedSide;
        }
        else if (rb.position.x > 0)
        {
            rb.velocity = transform.right * -speedSide;
        }
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime > timer && currentTime < timer + 1)
        {
            rb.velocity = Vector3.zero;
        }
        if (currentTime > waitTime)
        {
            rb.velocity = transform.up * -speedDown;
        }
    }

    private void FixedUpdate()
    {
        if (rb.velocity.x > 0)
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -50, right.transform.position.x - 0.4f), transform.position.y, transform.position.z);
        }
        else if (rb.velocity.x < 0)
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, left.transform.position.x + 0.4f, 50), transform.position.y, transform.position.z);
        }
    }
}
