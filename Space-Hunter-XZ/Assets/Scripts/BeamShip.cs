using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamShip : MonoBehaviour
{
    public GameObject beamLeft;
    public GameObject beamRight;
    public GameObject beamShip;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetString("GameMode") == "Hard")
        {
            Invoke("StartBeam", 0.8f);
            Invoke("StopBeam", 3.5f);
        } else
        {
            Invoke("StartBeam", 1.2f);
            Invoke("StopBeam", 5.25f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartBeam()
    {
        if (beamShip != null)
        {
            beamLeft.SetActive(true);
            beamRight.SetActive(true);
        }
    }

    void StopBeam()
    {
        if (beamShip != null)
        {
            beamLeft.SetActive(false);
            beamRight.SetActive(false);
        }
    }
}
