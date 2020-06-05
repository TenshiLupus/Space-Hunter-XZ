using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvasiveManeuver : MonoBehaviour
{
    public float speed;
    public float dodge;
    public float smoothing;
    public float tilt;
    public Vector2 startWait;
    public Vector2 maneuverTime;
    public Vector2 maneuverWait;
    public Boundary boundary;
    public GameObject top;
    public GameObject bottom;
    public GameObject left;
    public GameObject right;


    private float currentSpeed;
    private float targetManeuver;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        top = GameObject.Find("BoundaryTop");
        bottom = GameObject.Find("BoundaryBottom");
        left = GameObject.Find("BoundaryLeft");
        right = GameObject.Find("BoundaryRight");
        currentSpeed = speed;
        StartCoroutine(Evade());
    }

    IEnumerator Evade ()
    {
        yield return new WaitForSeconds(Random.Range(startWait.x, startWait.y));
        while (true)
        {
            targetManeuver = Random.Range(1, dodge) * -Mathf.Sign(transform.position.x);
            yield return new WaitForSeconds(Random.Range (maneuverTime.x, maneuverTime.y));
            targetManeuver = 0;
            yield return new WaitForSeconds(Random.Range (maneuverWait.x, maneuverWait.y));
        }
    }

    void FixedUpdate()
    {
        float newManeuver = Mathf.MoveTowards(rb.velocity.x, targetManeuver, Time.deltaTime * smoothing);
        rb.velocity = new Vector3(newManeuver, currentSpeed, 0.0f);
        rb.position = new Vector3
        (
            Mathf.Clamp(rb.position.x, left.transform.position.x+0.2f, right.transform.position.x-0.2f),
            Mathf.Clamp(rb.position.y, bottom.transform.position.y-4, top.transform.position.y+4),
            0.0f
         );

        rb.rotation = Quaternion.Euler(0.0f, Mathf.Clamp(rb.velocity.x * -tilt, -45f, 45f), 0.0f);
    }
}
