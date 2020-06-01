using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpActions : MonoBehaviour
{
    public GameObject laserPickUp;

    [SerializeField]
    private Player player;
    private PowerUpController controller;
    private GameController gameController;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        controller = GameObject.FindWithTag("PowerUpController").GetComponent<PowerUpController>();
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();

    }

    public void HighSpeedStartAction()
    {
        player.fireRate /= 2;
        controller.laserUpActive = true;
        Instantiate(laserPickUp, transform.position, transform.rotation);
    }

    public void HighSpeedEndAction()
    {
        player.fireRate *= 2;
        controller.laserUpActive = false;
    }

    public void AdvWeaponStartAction()
    {
        gameController.advancedWeapon = true;
        controller.AdvWeaponActive = true;
    }

    public void AdvWeaponEndAction()
    {
        gameController.advancedWeapon = false;
        controller.AdvWeaponActive = false;
    }
    public void LifeStartAction()
    {
        gameController.GiveLife();
    }

}
