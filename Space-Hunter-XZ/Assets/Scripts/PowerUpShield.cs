﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpShield : MonoBehaviour
{
    private PowerUpController controller;
    void Awake()
    {
        controller = GameObject.FindWithTag("PowerUpController").GetComponent<PowerUpController>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.transform.GetChild(2).gameObject.SetActive(true);
            controller.shieldUpActive = true;
            other.GetComponent<CapsuleCollider>().enabled =false;
            Destroy(gameObject);

        }
        if (other.gameObject.tag == "Shield")
        {
            Destroy(gameObject);
        }

    }
}
