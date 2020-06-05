using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    public GameObject explosion;
    public GameObject explosionSmall;
    public GameObject playerExplosion;
    public GameObject shieldExplosion;
    public GameObject advancedWeapon;
    public GameObject beamLeft;
    public GameObject beamRight;
    public Renderer renderer;
    public Material materialNormal;
    public Material materialHighlight;
    public int scoreValue;
    public int health;

    private GameController gameController;
    private PowerUpController powerUpController;
    private GameObject player;

    private bool respawn;
    private bool playerDied;

    void Start()
    {
        if (this.gameObject.CompareTag("Bullet") || this.gameObject.CompareTag("EnemyBullet")) {
            renderer = null;
         } else {
            renderer = GetComponentInChildren<MeshRenderer>();
        }
        player = GameObject.FindWithTag("Player");
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
        respawn = false;
    }
    void OnTriggerEnter(Collider other)
    {
        playerDied = false;
        if (other.CompareTag("Beam") || other.CompareTag("EnemyBullet") || other.CompareTag("ExplosiveBarrel") ||other.CompareTag("Boundary") || other.CompareTag("Enemy") || other.CompareTag("EnemyAdv") || other.CompareTag("Wall") || other.CompareTag("PowerUp"))
        {
            return;
        }
        if (explosion != null)
        {
            Instantiate(explosionSmall, new Vector3(transform.position.x, transform.position.y-0.3f, transform.position.z), transform.rotation);
        }
        if (other.CompareTag("Shield")) {
            other.GetComponent<Shield>().Explosion();
            powerUpController.shieldUpActive = false;
            Handheld.Vibrate();
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
            if(gameController.GetLife() < 1){
                Instantiate(explosion, transform.position, transform.rotation);
                other.GetComponent<Player>().Explosion();
                other.GetComponent<Player>().TriggerDestruction(true);
                health = 0;
            }
            else if(gameController.GetLife() >=1){
                gameController.TakeLife();
                Instantiate(explosion, transform.position, transform.rotation);
                other.GetComponent<Player>().Explosion();
                other.GetComponent<Player>().TriggerDestruction(false);
                health = 0;
                playerDied = true;
                respawn = true;
            }
        }
        if (!respawn)
        {
            Destroy(other.gameObject);
        }
        if (beamLeft != null && beamRight != null)
        {
            beamLeft.SetActive(false);
            beamRight.SetActive(false);
            Instantiate(explosion, transform.position, transform.rotation);
        }
        if (health <= 1 && renderer != null)
        {
            ChangeMaterial();
            Invoke("Destroy", 0.1f);
            Invoke("Explosion", 0.1f);
        }
        if (health > 1 && renderer != null)
        {
            ChangeMaterial();
            health -= 1;
            Invoke("ResetColor", 0.1f);
        }
        if (renderer == null && !other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

    private void ChangeMaterial()
    {
        renderer.material = materialHighlight;
    }

    public void TriggerDestruction ()
    {
        ChangeMaterial();
        if (beamLeft != null && beamRight != null)
        {
            Destroy(beamLeft);
            Destroy(beamRight);
        }
        Invoke("Explosion", 0.1f);
        Invoke("Destroy", 0.1f);
    }
    public void Explosion()
    {
        Instantiate(explosion, transform.position, transform.rotation);
    }
    public void Destroy()
    {
        if (gameObject.CompareTag("EnemyAdv") && gameController.advancedWeaponReady)
        {
            gameController.StartWeaponSpawnTimer();
            if (!playerDied) {
                Instantiate(advancedWeapon, transform.position, new Quaternion(0, 0, 0, 0));
            }
        }
        if (!playerDied) {
                gameController.AddScore(scoreValue);
            }
        Destroy(gameObject);
    }
    public void ResetColor()
    {
        this.GetComponent<MeshRenderer>().material = materialNormal;
    }
}
