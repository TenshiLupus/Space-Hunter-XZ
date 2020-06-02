using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rescale : MonoBehaviour
{
    void Start()
    {
        //initialMultiplier = 1f;
    }

    void Update()
    {
        float height = Camera.main.orthographicSize * 2f;
        float width = (height / Screen.height * Screen.width);
        if (transform.localScale.x != width)
        {
            transform.localScale = new Vector3(width, transform.localScale.y, transform.localScale.z);
        }
        if (transform.localScale.y != height)
        {
            transform.localScale = new Vector3(transform.localScale.x, 5 + height, transform.localScale.z);
        }
    }
}
