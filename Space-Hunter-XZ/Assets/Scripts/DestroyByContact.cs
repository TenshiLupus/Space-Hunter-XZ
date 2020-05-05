using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;
    public GameObject shieldExplosion;
    public int scoreValue;

    private GameController gameController;
    private PowerUpController powerUpController;
    private GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        powerUpController = GameObject.FindWithTag("PowerUpController").GetComponent<PowerUpController>();
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if(gameController == null)
        {
            Debug.Log("Cannot Find 'GameController' script");
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boundary") || other.CompareTag("Enemy"))
        {
            return;
        } 
        if (explosion != null)
        {
            Instantiate(explosion, transform.position, transform.rotation);
        }
        if (other.CompareTag("Shield")) {
            Instantiate(shieldExplosion, transform.position, transform.rotation);
            powerUpController.shieldUpActive = false;
            other.gameObject.SetActive(false);
            Destroy(gameObject);
            other.GetComponentInParent<CapsuleCollider>().enabled = true;
            return;
        }
        if (other.CompareTag("Hazard"))
        {
            Instantiate(explosion, transform.position, transform.rotation);
        }
        if (other.CompareTag("Player"))
        {
            if(gameController.GetLife()<1){
            Instantiate(playerExplosion, transform.position, transform.rotation);
            gameController.GameOver();
            }
            else if(gameController.GetLife()>=1){
                gameController.TakeLife();
                Instantiate(playerExplosion, transform.position, transform.rotation);
                player.transform.position = new Vector3(0, 0, 0);
            }
        }
        gameController.AddScore(scoreValue);
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
