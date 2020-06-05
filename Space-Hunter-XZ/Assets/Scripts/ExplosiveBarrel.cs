using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveBarrel : MonoBehaviour
{
    CapsuleCollider colCapsule;
    public GameObject explosion;
    public GameObject explosionLarge;
    public GameObject explosionSmall;
    public GameObject waveObject;
    public Renderer renderer;
    public Material materialNormal;
    public Material materialHighlight;

    private GameController gameController;
    private PowerUpController powerUpController;

    public float radius;
    public int health;

    private bool blowedUp;
    
    private void Awake() {
        powerUpController = GameObject.FindWithTag("PowerUpController").GetComponent<PowerUpController>();
        gameController =  GameObject.FindWithTag("GameController").GetComponent<GameController>();
        colCapsule = GetComponent<CapsuleCollider>();
        blowedUp = false;
    }

     void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Bullet") || other.CompareTag("EnemyBullet"))
        {
            if (!blowedUp  && health <= 1)
            {
                blowedUp = true;
                ChangeMaterial();
                Invoke("Destroy", 0.1f);
                Invoke("Explode", 0.1f);
            }
            else if (health > 1)
            {
                Instantiate(explosionSmall, new Vector3(transform.position.x, transform.position.y - 0.3f, transform.position.z), transform.rotation);
                ChangeMaterial();
                health -= 1;
                Invoke("ResetColor", 0.1f);
                if (other.CompareTag("EnemyBullet"))
                {
                    Destroy(other.gameObject);
                }
            }
        }
        if (other.CompareTag("Player")) {
            blowedUp = true;
            ChangeMaterial();
            Invoke("Destroy", 0.1f);
            Invoke("Explode", 0.1f);
        }
        if (other.CompareTag("Enemy"))
        {
            blowedUp = true;
            ChangeMaterial();
            Invoke("Destroy", 0.2f);
            Invoke("Explode", 0.1f);
            Instantiate(explosion, transform.position, transform.rotation);
            other.GetComponent<DestroyByContact>().TriggerDestruction();
        }
        if (other.CompareTag("Shield"))
        {
            Explode();
        }
     }
    private void ChangeMaterial()
    {
        renderer.material = materialHighlight;
    }
    public void ResetColor()
    {
        this.GetComponent<MeshRenderer>().material = materialNormal;
    }

    void Destroy ()
    {
        Destroy(gameObject);
    }
    void Explode(){
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        Instantiate(explosionLarge, transform.position, transform.rotation);
        //Instantiate(waveObject, transform.position, transform.rotation);
        foreach(Collider nearbyObject in colliders)
        {
            GameObject other = nearbyObject.gameObject;
            if (other.CompareTag("Enemy") || other.CompareTag("Hazard"))
            {
                other.GetComponent<DestroyByContact>().Explosion(); 
                other.GetComponent<DestroyByContact>().TriggerDestruction();
            }
            if (other.CompareTag("ExplosiveBarrel") && !other == this)
            {
                other.GetComponent<ExplosiveBarrel>().Explode();
            }
            if (other.CompareTag("Shield"))
            {
                other.GetComponent<Shield>().Explosion();
                powerUpController.shieldUpActive = false;
                Handheld.Vibrate();
                other.gameObject.SetActive(false);
                Destroy(gameObject);
                other.GetComponentInParent<CapsuleCollider>().enabled = true;
            }
            if (other.CompareTag("Player"))
            {
                if (gameController.GetLife() < 1)
                {
                    other.GetComponent<Player>().TriggerDestruction(true);
                    other.GetComponent<Player>().Explosion();
                } else if (gameController.GetLife() >= 1)
                {
                    gameController.TakeLife();
                    other.GetComponent<Player>().TriggerDestruction(false);
                    other.GetComponent<Player>().Explosion();
                }
            }
            //Handheld.Vibrate();
        }
        Destroy(gameObject);
    }

}
