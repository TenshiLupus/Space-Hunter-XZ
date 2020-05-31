using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rescale : MonoBehaviour
{
    float initialScreenWidth;
    float initialScreenHeight;
    float UpdatedScreenSize;
    float newRatio;
    float initialMultiplier;
    float changes;
    void Start()
    {
        //initialMultiplier = 1f;
    }
    
    public void setSizeX(float newRatio)
    {
        transform.localScale = new Vector3((transform.localScale.x) * newRatio, 1, 1);
    }

    public float GetNewRatioX()
    {
        float height = Camera.main.orthographicSize * 2f;
        float width =(height / Screen.height * Screen.width);
        float newRatio = width / height;
        return newRatio; 
    }
    // Update is called once per frame
    void Update()
    {
        //changes = Screen.width 
    }


    public void ReSize()
    { 
        //transform.localScale.x * initialMultiplier *  
        float ratio = GetNewRatioX();
        setSizeX(ratio);
    }
}
