using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoltRotation : MonoBehaviour
{
    public GameObject interfaceObject;
    public GameObject background;
    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = new Quaternion(0,0,0,0); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
