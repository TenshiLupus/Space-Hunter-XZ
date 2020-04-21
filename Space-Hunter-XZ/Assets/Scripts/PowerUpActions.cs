using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpActions : MonoBehaviour
{
    [SerializeField]
    private Player player;

    public void HighSpeedStartAction(){
        player.fireRate *= 2;
    }

    public void HighSpeedEndAction(){
        player.fireRate *= 1;
    }
}
