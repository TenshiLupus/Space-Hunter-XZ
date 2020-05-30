using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;
    public GameObject shieldExplosion;
    public Renderer renderer;
    public Material materialNormal;
    public Material materialHighlight;
    public int scoreValue;
    public int health;

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
        if (other.CompareTag("Boundary") || other.CompareTag("Enemy") || other.CompareTag("Wall"))
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
        Destroy(other.gameObject);
        if (health <= 1 && renderer != null)
        {
            renderer.material = materialHighlight;
            gameController.AddScore(scoreValue);
            Invoke("Destroy", 0.1f);
        }
        if (health > 1 && renderer != null)
        {
            renderer.material = materialHighlight;
            health -= 1;
            Invoke("ResetShader", 0.1f);
        }
        if (renderer == null)
        {
            Destroy(gameObject);
        }
    }
    public void Destroy()
    {
        Destroy(gameObject);
    }
    public void ResetShader()
    {
        this.GetComponent<MeshRenderer>().material = materialNormal;
    }
}
