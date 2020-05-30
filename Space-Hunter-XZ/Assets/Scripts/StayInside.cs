﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayInside : MonoBehaviour {

	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -2.4f, 2.4f),
            Mathf.Clamp(transform.position.y, -0.2f, 8f), transform.position.z);
	}
}
