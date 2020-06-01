using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayInside : MonoBehaviour {

	public GameObject top;
	public GameObject bottom;
	public GameObject left;
	public GameObject right;
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, left.transform.position.x, right.transform.position.x),
            Mathf.Clamp(transform.position.y, bottom.transform.position.y, top.transform.position.y), transform.position.z);
	}
}
