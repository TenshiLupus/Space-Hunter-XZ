﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpActions : MonoBehaviour
{
    public GameObject laserPickUp;

    [SerializeField]
    private Player player;
    private PowerUpController controller;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        controller = GameObject.FindWithTag("PowerUpController").GetComponent<PowerUpController>();

    }

    public void HighSpeedStartAction(){
        player.fireRate /= 2;
        controller.laserUpActive = true;
        Instantiate(laserPickUp, transform.position, transform.rotation);
    }

    public void HighSpeedEndAction(){
        player.fireRate *= 2;
        controller.laserUpActive = false;
    }
}
