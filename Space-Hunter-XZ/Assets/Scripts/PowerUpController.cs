using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpController : MonoBehaviour
{
    public GameObject powerupPrefab;

    public List<Powerup> powerups;
    public Dictionary<Powerup, float> activePowerups = new Dictionary<Powerup, float>();
    public bool shieldUpActive;
    public bool laserUpActive;
    public bool AdvWeaponActive;

    private List<Powerup> keys = new List<Powerup>();

    void Update()
    {
        HandeActivePowerups();
    }
    public void HandeActivePowerups()
    {
        bool changed = false;

        if (activePowerups.Count > 0)
        {

            foreach (Powerup powerUp in keys)
            {
                if (activePowerups[powerUp] > 0)
                {
                    activePowerups[powerUp] -= Time.deltaTime;
                }
                else
                {
                    powerUp.End();
                    changed = true;
                    activePowerups.Remove(powerUp);
                }
            }
        }

        if (changed)
        {
            keys = new List<Powerup>(activePowerups.Keys);
        }
    }

    public void ActivatePowerup(Powerup powerUp)
    {
        if (keys.Contains(powerUp))
        {
            foreach (Powerup p in keys) {
                if (p.name == powerUp.name)
                {
                    p.End();
                }
            }
            activePowerups.Remove(powerUp);
            keys.Remove(powerUp);
            powerUp.Start();
            activePowerups.Add(powerUp, powerUp.duration);
        }
        else
        {
            powerUp.Start();
            activePowerups.Add(powerUp, powerUp.duration);
        }
        keys = new List<Powerup>(activePowerups.Keys);
    }

    public GameObject SpawnPowerup(Powerup powerUp, Vector3 position)
    {
        GameObject powerupGameObject = Instantiate(powerupPrefab);

        var powerupBehaviour = powerupGameObject.GetComponent<PowerupBehaviour>();

        powerupBehaviour.controller = this;

        powerupBehaviour.SetPowerup(powerUp);

        powerupGameObject.transform.position = position;

        return powerupGameObject;
    }
}
