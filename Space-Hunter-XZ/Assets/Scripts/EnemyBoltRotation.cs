using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoltRotation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Quaternion rotation = new Quaternion(0, 0, 0, 0);
        transform.rotation = rotation;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
