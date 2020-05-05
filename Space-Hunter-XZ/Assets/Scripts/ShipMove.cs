using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMove : MonoBehaviour {

    private Vector3 mousePosition;
    private Rigidbody rb;
    private Vector2 direction;
    public float moveSpeed;

    public float tilt;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0))
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            direction = (mousePosition - transform.position).normalized;
            rb.velocity = new Vector2(direction.x * moveSpeed, direction.y * moveSpeed);
            rb.rotation = Quaternion.Euler(0.0f, Mathf.Clamp(rb.velocity.x * -tilt, -45f, 45f), 0.0f);
        }
        else {
            rb.velocity = Vector2.zero;
        }
    }
}
