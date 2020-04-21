﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpController : MonoBehaviour
{
    public GameObject powerupPrefab;

    public List<Powerup> powerups;
    public Dictionary<Powerup, float> activePowerups = new Dictionary<Powerup, float>();

    private List<Powerup> keys = new List<Powerup>();

    void Update() {
        HandeActivePowerups();    
    }
    public void HandeActivePowerups(){
        bool changed = false;

        if(activePowerups.Count > 0){

            foreach(Powerup powerUp in keys){
                if(activePowerups[powerUp]> 0){
                    activePowerups[powerUp] -= Time.deltaTime;
                }
                else changed = true;
                activePowerups.Remove(powerUp);

                powerUp.End();
            }
        }

        if(changed){
            keys = new List<Powerup>(activePowerups.Keys);
        }
    }

    public void ActivatePowerup (Powerup powerUp){
        if(!activePowerups.ContainsKey(powerUp)){
            powerUp.Start();
            activePowerups.Add(powerUp, powerUp.duration);
        }
        else{
            activePowerups[powerUp] += powerUp.duration;
        }

        keys = new List<Powerup>(activePowerups.Keys);
    }

    public GameObject SpawnPowerup(Powerup powerUp, Vector3 position){
        GameObject powerupGameObject = Instantiate(powerupPrefab);

        var powerupBehaviour = powerupGameObject.GetComponent<PowerupBehaviour>();

        powerupBehaviour.controller = this;

        powerupBehaviour.SetPowerup(powerUp);

        powerupGameObject.transform.position = position;

        return powerupGameObject;
    }
}