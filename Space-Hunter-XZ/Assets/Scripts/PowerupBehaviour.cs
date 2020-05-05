using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupBehaviour : MonoBehaviour
{
    public PowerUpController controller;
    [SerializeField]
    private Powerup powerup;

    private Transform transform_;

    private void Awake() {
        transform_ = transform;
        controller = GameObject.FindWithTag("PowerUpController").GetComponent<PowerUpController>();
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player"){
            ActivatePowerup();
            gameObject.SetActive(false);
            Invoke("Delete", powerup.duration +1);

        }
        
    }

    private void Delete()
    {
        Destroy(gameObject);
    }

    private void ActivatePowerup(){
        controller.ActivatePowerup(powerup);
    }

    public void SetPowerup(Powerup powerup){
        this.powerup = powerup;
        gameObject.name = powerup.name;
    }
}
