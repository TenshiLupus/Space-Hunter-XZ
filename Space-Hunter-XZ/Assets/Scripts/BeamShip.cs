using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamShip : MonoBehaviour
{
    public GameObject beamLeft;
    public GameObject beamRight;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("StartBeam", 1);
        Invoke("StopBeam", 2.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartBeam()
    {
        beamLeft.SetActive(true);
        beamRight.SetActive(true);
    }

    void StopBeam()
    {
        beamLeft.SetActive(false);
        beamRight.SetActive(false);
    }
}
